const cacheName = "DefaultCompany-Ball-0.1";
const contentToCache = [
    "Build/BUILD2.loader.js",
    "Build/caffa8e1f5c71dd7e6fec1d8395c098d.js.unityweb",
    "Build/dcdb643b1720be01361fc7fd9c55b532.data.unityweb",
    "Build/c24db23acee3253bf0f496bf2da67ac1.wasm.unityweb",
    "TemplateData/style.css"

];

self.addEventListener('install', function (e) {
    console.log('[Service Worker] Install');
    
    e.waitUntil((async function () {
      const cache = await caches.open(cacheName);
      console.log('[Service Worker] Caching all: app shell and content');
      await cache.addAll(contentToCache);
    })());
});

self.addEventListener('fetch', function (e) {
    e.respondWith((async function () {
      let response = await caches.match(e.request);
      console.log(`[Service Worker] Fetching resource: ${e.request.url}`);
      if (response) { return response; }

      response = await fetch(e.request);
      const cache = await caches.open(cacheName);
      console.log(`[Service Worker] Caching new resource: ${e.request.url}`);
      cache.put(e.request, response.clone());
      return response;
    })());
});
