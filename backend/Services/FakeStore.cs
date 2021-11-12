using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using backend.Interfaces;
using backend.Models;

namespace backend.Services
{
    public class FakeStore: IFakeStore
    {
        public string BaseUrl;

        public FakeStore()
        {
            BaseUrl = "https://fakestoreapi.com";
        }

        string IFakeStore.BaseUrl => BaseUrl;

        public async Task AddProduct(Products product)
        {
            try
            {
                var payload = JsonConvert.SerializeObject(new {
                    title = product.name,
                    price = product.price,
                    description = " ",
                    image = product.image,
                    category = "root"
                });
                var data = new StringContent(payload, Encoding.UTF8, "application/json");

                var client = new HttpClient();

                var response = await client.PostAsync($"{BaseUrl}/products", data);

                var result = await response.Content.ReadAsStringAsync();   
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
        public async Task UpdateProduct(int id, Products product)
        {
            try
            {
                var payload = JsonConvert.SerializeObject(new {
                    title = product.name,
                    price = product.price,
                    description = " ",
                    image = product.image,
                    category = "root"
                });
                var data = new StringContent(payload, Encoding.UTF8, "application/json");

                var client = new HttpClient();

                var response = await client.PutAsync($"{BaseUrl}/products/{id}", data);

                var result = await response.Content.ReadAsStringAsync();    
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task DeleteProduct(int id)
        {
            try
            {
                var client = new HttpClient();

                var response = await client.DeleteAsync($"{BaseUrl}/products/{id}");

                var result = await response.Content.ReadAsStringAsync();    
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
    
}