﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShopApi.WebUI.Dtos.DrinkDtos;
using TeaShopApi.WebUI.Dtos.TestimonialDtos;

namespace TeaShopApi.WebUI.ViewComponents.Default
{
    public class _TestimonialListComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TestimonialListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7181/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
