سلام وقتتون بخیر پروژه بالا دوتا کلاس ساده برای ارسال پیام و عکس و فایل به تلگرام هست.

` // example : 541565:511555:51556:51561515 `
>var botToken = "توکن دریافتی از تلگرام در این قسمت قرار بدید";
___


` // example : @telegramIran `
>var ChannelId = "ادرس پابلیک کانال تلگرام هم اینجا بذارین" 
___
دقت کنید که ادرس و api تلگرام به صورت worker تلگرام معرفی شده در برنامه در زیر ادرس رو براتون میذارم : 

` // api.telegram.org => worker ` 
>https://mtorgforiranserver.mohammad-bahonar1.workers.dev/

___

آدرس بالا رو با ادرس ورکر خودتون در کلود فلر جایگزین کنین. که روزانه بهتون صد هزار ریکوئست رو اجازه رو بده .

```csharp
async function handleRequest(request) {
	const url = new URL(request.url);
	// Change the hostname to 'api.telegram.org'
	url.hostname = 'api.telegram.org';
	// Create a new request with the modified URL
	const newRequest = new Request(url.toString(), request);
	// Fetch and return the response from the new URL
	try {
	  const response = await fetch(newRequest);
	  return response;
	} catch (error) {
	  // Handle errors, if any
	  return new Response('Internal Server Error', {
		status: 500,
		headers: {
		  'content-type': 'text/plain',
		},
	  });
	}

  }
  addEventListener('fetch', (event) => {
	event.respondWith(handleRequest(event.request));
});
```
آموزش ساخت ورکر تلگرام مسیر زیر را طی کنید : 
go to  - __[cloudflare.com](https://cloudflare.com/)__ => signUp => login => Workers & Pages => create => Create Worker => add Name for Worker => select deploy => Edit Code => paste up Code => select deploy => Finish
