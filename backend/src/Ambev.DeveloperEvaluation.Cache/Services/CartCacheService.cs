using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Caches;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace Ambev.DeveloperEvaluation.Cache.Services
{
    public class CartCacheService : ICartCacheService
    {

        private readonly IDatabase _db;

        public CartCacheService(IConnectionMultiplexer redis)
        {
            _db = redis.GetDatabase();
        }

        public async Task<Cart?> GetCartByIdAsync(long id)
        {
            var cacheKey = $"cart:{id}";
            var cartJson = await _db.StringGetAsync(cacheKey);

            Cart? cart = null;
            if (!cartJson.IsNullOrEmpty)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters = { new JsonStringEnumConverter() }
                };

                cart = JsonSerializer.Deserialize<Cart>(cartJson.ToString(), options);

            }

            return cart;
        }

        public async Task Delete(long id)
        {
            Cart? cart = await GetCartByIdAsync(id);

            if (cart != null)
            {
                var userCacheKey = $"cart:user:{cart.UserId}";
                await _db.KeyDeleteAsync(userCacheKey);
            }
            await _db.KeyDeleteAsync($"cart:{id}");
        }

        public async Task<IQueryable<Cart>> GetQueryableAsync()
        {

            var keys = GetAllKeys();

            var carts = new List<Cart>();

            foreach (var key in keys)
            {
                var json = await _db.StringGetAsync(key);

                if (!json.IsNullOrEmpty)
                {
                    var cart = JsonSerializer.Deserialize<Cart>(json.ToString());
                    if (cart != null)
                        carts.Add(cart);
                }
            }

            return carts.AsQueryable();
        }

        private IEnumerable<RedisKey> GetAllKeys()
        {
            var server = _db.Multiplexer.GetServer(_db.Multiplexer.GetEndPoints().First());
            var keys = server.Keys(pattern: "cart:*");
            return keys;
        }

        public async Task<Cart> AddASync(Cart cart)
        {
            // Incrementa o contador para o ID do carrinho
            var cartId = await _db.StringIncrementAsync("cart:counter");

            cart.Id = cartId;

            // Serializa o carrinho para JSON
            var jsonData = JsonSerializer.Serialize(cart, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false
            });

            // Cria a chave do carrinho com ID
            var cacheKey = $"cart:{cart.Id}";

            // Cria a chave auxiliar para associar o UserId ao carrinho
            var userCacheKey = $"cart:user:{cart.UserId}";

            // Verifica se já existe um carrinho para o UserId
            var existingCartId = await _db.StringGetAsync(userCacheKey);
            if (!existingCartId.IsNullOrEmpty)
            {
                // Se já existir, apaga o carrinho anterior (por exemplo, sobrescreve)
                await _db.KeyDeleteAsync($"cart:{existingCartId}");
            }

            // Salva o novo carrinho com o ID gerado
            await _db.StringSetAsync(cacheKey, jsonData, TimeSpan.FromHours(12));

            // Atualiza a chave auxiliar com o novo carrinho
            await _db.StringSetAsync(userCacheKey, cart.Id, TimeSpan.FromHours(12));

            return cart;
        }

        public async Task Update(Cart cart)
        {
            var cacheKey = $"cart:{cart.Id}";
            var jsonData = JsonSerializer.Serialize(cart, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false
            });
            await _db.StringSetAsync(cacheKey, jsonData, TimeSpan.FromHours(4));
        }

    }
}
