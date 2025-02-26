﻿using System;
using BadNews.Models.Editor;
using BadNews.Repositories.News;
using Microsoft.AspNetCore.Mvc;

namespace BadNews.Controllers
{
    public class EditorController : Controller
    {
        private readonly INewsRepository _newsRepository;

        public EditorController(INewsRepository newsRepository)
        {
            this._newsRepository = newsRepository;
        }

        public IActionResult Index()
        {
            return View(new IndexViewModel());
        }
        
        [HttpPost]
        public IActionResult CreateArticle([FromForm] IndexViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);
            
            var id = _newsRepository.CreateArticle(new NewsArticle {
                Date = DateTime.Now.Date,
                Header = model.Header,
                Teaser = model.Teaser,
                ContentHtml = model.ContentHtml,
            });

            return RedirectToAction("FullArticle", "News", new {
                id = id
            });
        }
    }
}