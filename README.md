**Core 3.0 ile Swagger Kullanmak**

   Merhabalar bir süredir kullanmakta olduğum swagger hakkında öğrendiğim kadarıyla, kullanım ve kullanım örnekleri ile farklı bir yazı ile devam etmek istiyorum. Swagger nedir?, nasıl kurulur, nasıl kullanılır ne işimize yarayacak gibi soruların cevaplarını bulmaya çalışacağız.
   
  Swagger’a geçmeden önce API hakkında birkaç şey söylemek gerekiyor. API’ler artık günlük projelerimizin olmazsa olmazı haline gelmeye başladı özellikle mobil uygulamaların artması ile hem web, hem windows hemde mobil uygulamalar için ortak bir katman olan API’ler daha fazla karşılaşmaya başladık. API’lerin rest , soap gibi detaylarına girmeyeceğim amacım swagger’i etkin olarak nasıl kullanırız olacaktır.

API hizmeti verdiğimiz yada aldığımız durumlarda birde dökümantasyon gibi önemli ve bir o kadarda iş yükü beraberinde gelmekte, servislere ait hangi method hangi parametreler ile istek alıyordu, istek objesine eklenen ya da çıkarılan bir nesne oldumu, response içerisinde neler değişti gibi birçok soru beraberinde gelmekte. Her güncelleme durumunda dökümanı da aynı şekilde güncel tutmak gerekmektedir, işte tam da burada SWAGGER imdadımıza yetişiyor.

**Swagger ?**

Swagger aslında bahsetmiş olduğum API hizmetleri için bir dökümantasyondur. Swagger RestApi’ler için bir nevi arayüz sağlamaktadır. Entity, DataAcces ve Business katmanlarını hazır olduğunu düşünelim ve API projesinide yazdık eee ne var bunda burada WebUI katmanını yazmadan veya Mobil katmanlarını yazmadan sağlama da yapabileceğiz demek! O nasıl oluyor ki :) Şimdi Swagger ile API’lerin testlerini çalıştırarak testlerin başarılı olup olmadığını backend tarafında olası hataları arayüz katmanını yazmadan da tespit edebileceğimiz anlamına geliyor. Kulağa hoş geliyor gibi.

Ufak bir örnek üzerinden anlatmaya çalışacağım.

-  Bir adet **Core 3.0 WebAPI** projesi oluşturacağız,
- Bir adet **api controller** (StudentsController) oluşturacağız,
- Bir adet de Student nesnemiz oluyor olacak,
- StudentsController içerisinde **Get,Post,Put,Delete** işlemlerine örnek olması amacıyla birer adet method oluşturacağız,
- **appsettings.json** dosyasında swagger ayarlaması yapıp **GetSection** ile bu ayarları okuyacağız,
- **ProducesResponseType** ile swagger’ı biraz daha kullanıcı dostu haline getirip zenginleştireceğiz.
- Method *commentlerinin swagger da görüntülenmesi* için optimizasyon yapacağız.
- **pragma warning disable** ile uyarıların nasıl dikkate alınmayacağı gibi ufak tefek işimizi kolaylaştıracak ayarlar yapıyor olacağız.

1.  İlk olarak projemizi

[![](https://miro.medium.com/max/986/1*yFxf-HzWfTt3u7fPCOtjCg.png)](https://miro.medium.com/max/986/1*yFxf-HzWfTt3u7fPCOtjCg.png)


2.  Student nesnesi oluşturalım. Ben örnek olması amacı ile sadece 4 adet attribute ekledim istediğiniz gibi değiştirebilirsiniz, ve DBContext gibi işlemler ile uğraşmamak için sadece List döndüren dami data olması amacıyla bir adet static metot oluşturdum.

[![](https://miro.medium.com/max/447/1*pAlcwFmnzs-ORp1BnYFNFg.png)](https://miro.medium.com/max/447/1*pAlcwFmnzs-ORp1BnYFNFg.png)


3- StudentsController adında bir adet api controller ekledim. 1 adet GetList methodu (HttpGet) ekledim geri dönüş değeri ActionResult tipinde ayarladım burada yazılan kod örnekleri sadece swagger işlemlerini anlatmak adına yazılmıştır içerik isteğe ve ihtiyaca göre tamamen değişkenlik gösterebilir.

[![](https://miro.medium.com/max/385/1*nunCcmBCK-RC1u7gGuXhhg.png)](https://miro.medium.com/max/385/1*nunCcmBCK-RC1u7gGuXhhg.png)

4- Şimdi sıra geldi paket yöneticisi yardımı ile swagger eklentisini kurmaya.
Swashbuckle.AspNetCore olarak aratarak bulabilirsiniz. Burada sadece swagger eklentisini kurmadım çünkü **SwaggerGen,SwaggerUI** ve **Swagger** gibi *dependencies* leri de kullanımını göstermek amacım.

[![](https://miro.medium.com/max/1852/1*_nJNKwfwLKY5gxqVqzGvTA.png)](https://miro.medium.com/max/1852/1*_nJNKwfwLKY5gxqVqzGvTA.png)

Ek olarak **Microsoft.OpenApi** nesnesinide kuruyoruz.

[![](https://miro.medium.com/max/1357/1*DYIlcM0iiGpkkYA93dN4qg.png)](https://miro.medium.com/max/1357/1*DYIlcM0iiGpkkYA93dN4qg.png)

5- **Startup.cs** dosyası içerisinde şimdi swagger için configuration işlemleri ve middleware ekleme işlemlerini yapıyor olacağız.
Startup.cs içerisinde **ConfigureServices** metoduna ekliyoruz ;


[![](https://miro.medium.com/max/558/1*X-Srttz2lb9olTKREwYlvg.png)](https://miro.medium.com/max/558/1*X-Srttz2lb9olTKREwYlvg.png)


ve swagger için middleware ekliyoruz. Startup.cs içinde **Configure** metodu;

[![](https://miro.medium.com/max/786/1*gOUKvnI0GtKySE6qeHbN5A.png)](https://miro.medium.com/max/786/1*gOUKvnI0GtKySE6qeHbN5A.png)

~~Önemli bir husus~~
**İsimlendirme**: Swagger ile ilgili ayarlamaları yaparken **SwaggerDoc** içerisindeki **name** alanı ile **Swagger.EndPoint** noktasındaki isimlendirme eşlenik olmalı aksi durumda hata alacaktır.

[![](https://miro.medium.com/max/817/1*vY2Pid433ywClgxgomewiA.png)](https://miro.medium.com/max/817/1*vY2Pid433ywClgxgomewiA.png)


Daha önce bahsettiğim **SwaggerGen** dependency’i ile swagger da yapılandırma işlemi, lisans ve açıklama gibi bilgileri eklemek için kullanılmaktadır. [ **AddSwaggerGen** ]
Startup.cs içerisinde ayarlamalarımızı alttaki gibi yapıyoruz.

[![](https://miro.medium.com/max/634/1*CwwMDArfXnLzVvlwU5n2Hg.png)](https://miro.medium.com/max/634/1*CwwMDArfXnLzVvlwU5n2Hg.png)

Üstteki yapılandırma sonrası çalıştırdığımızda swagger sayfası alttaki gibi görünecektir.

[![](https://miro.medium.com/max/1025/1*sGw_d1QzHKVWmoKHkeOarQ.png)](https://miro.medium.com/max/1025/1*sGw_d1QzHKVWmoKHkeOarQ.png)

StudentsController içerisinde yazmış olduğumuz method’un çıktısı ise alttaki gibi olmaktadır.

[![](https://miro.medium.com/max/1750/1*UeFVkcJTwcbkTcfCHZZEWw.png)](https://miro.medium.com/max/1750/1*UeFVkcJTwcbkTcfCHZZEWw.png)

6- Şimdi response işlemlerini biraz daha iyileştirerek devam ediyoruz.[ProducesResponseType(201)], [ProducesResponseType(400)] gibi Attribute yardımı ile kullanıcıya çıktı verirken daha anlaşılır ve daha okunabilir, hata durumunda kullanıcı bilgilendirilmesi gibi işlemleri de bu şekilde kullanabiliriz. Bu eklentiler ile beraber swagger çıktısı alttaki gibi olacaktır.

[![](https://miro.medium.com/max/1662/1*wrMXy-LgRLAUWJnzt0ZP8A.png)](https://miro.medium.com/max/1662/1*wrMXy-LgRLAUWJnzt0ZP8A.png)

7- Kod blokları için gerektiği zaman commentler yazarız bunlar çalıştırılacak olan method hakkında bizlere bilgi sağlamaktadır. Ne işe yaradığı istenen parametreler ve geri dönüş değerleri gibi. Bu alanları metotların üstünde
/// <summary>
///
/// </summary>
/// <returns></returns>
şeklinde yazılmaktadır.
Swagger içerisinde bu alanlarında etkinleştirmek için configuration içerisinde bazı düzenlemeleri yapmamız gerekmektedir.

[![](https://miro.medium.com/max/747/1*FVkUxc-y1KczO_wIMCQJzQ.png)](https://miro.medium.com/max/747/1*FVkUxc-y1KczO_wIMCQJzQ.png)

var xmlFile =$”{Assembly.GetExecutingAssembly().GetName().Name}.xml”;
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
c.IncludeXmlComments(xmlPath);


[![](https://miro.medium.com/max/1527/1*PwlS44yCdmX4AH2xxdj5_A.png)](https://miro.medium.com/max/1527/1*PwlS44yCdmX4AH2xxdj5_A.png)

Bu ayarlamayı yaptıktan sonra swagger da karşımıza bu açıklama ve comment alanlarıda çıkmaktadır.

[![](https://miro.medium.com/max/1806/1*2dCtCYfcLf2lyNgId6zrJA.png)](https://miro.medium.com/max/1806/1*2dCtCYfcLf2lyNgId6zrJA.png)


8- Bazı kod bloklarında görmezden gelinebilecek uyarılar içinde yine aynı şekilde .csproj dosyası içerisinde ProperyGroups içerisine uyarı kodlarını ekleyebiliriz.
<NoWarn>$(NoWarn);1591</NoWarn>
Örnek olması açısından program.cs içerisindeki kod bloğunu bu şekilde uyarı alanı olarak ayarlayalım.

[![](https://miro.medium.com/max/639/1*lo82pCgo1Rb5CZAsArNWLw.png)](https://miro.medium.com/max/639/1*lo82pCgo1Rb5CZAsArNWLw.png)

Son olarak startup.cs dosyası içerisinde yazmış olduğumuz swagger ile ilgili ayarlama işlemlerini appsettings.json içerisine alarak dışardan değiştirilebilir , farklı yerlerden erişilebilir hale getiriyoruz.
appsettings.json içerisine swagger ile ile ilgili ayarlar için scope açıyoruz.

[![](https://miro.medium.com/max/917/1*Ak-eP2cG4OmXZw-5dOyPSQ.png)](https://miro.medium.com/max/917/1*Ak-eP2cG4OmXZw-5dOyPSQ.png)

Burada dikkatinizi çekmek istediğim nokta 2 yerde Swagger name bilgisi yazmaktadır. Ben isimlendirme sadece bir alanda tutup 2.ci alanda ki yere 1.ci alanda almış olduğum değeri set ediyor olacağım, o yüzden UseSwaggerUI scope içerisindeki SwaggerEndPoint alanını string Format şeklinde kodladım. Birazdan startup.cs içerisinde bu alanı neden bu şekilde kullandığımı daha iyi anlamış olacağız.

[![](https://miro.medium.com/max/907/1*NT-ay39GUkwCXGZ6u392TQ.png)](https://miro.medium.com/max/907/1*NT-ay39GUkwCXGZ6u392TQ.png)


Core ile beraber appsettings.json içerisinden okumak için Configuration nesnesinin GetSection metodu yardımı ile okuyor olacağım.
Şimdi ise swagger middleware için json dosyasında okuma yapalım.

[![](https://miro.medium.com/max/1087/1*BY6fWajcusE6nklIVOtO6A.png)](https://miro.medium.com/max/1087/1*BY6fWajcusE6nklIVOtO6A.png)

Tüm ayarlamaları yaptıktan sonra örnek için bir kaç metot daha yazıp tekrar çalıştırıyoruz.

[![](https://miro.medium.com/max/1190/1*qMFSSh_Cu7EihcIba6tqEw.png)](https://miro.medium.com/max/1190/1*qMFSSh_Cu7EihcIba6tqEw.png)


Shema içerisinde API istek ve cevaplarında (request ve response) kullanılan nesneler (Class,Dto vb…) shema içerisinde görünüyor olacaktır.

[![](https://miro.medium.com/max/1171/1*88VHv8QXvDFKIlWThgEuOg.png)](https://miro.medium.com/max/1171/1*88VHv8QXvDFKIlWThgEuOg.png)

[![](https://miro.medium.com/max/1177/1*n8oKDRV8hpLPrEe27PCyug.png)](https://miro.medium.com/max/1177/1*n8oKDRV8hpLPrEe27PCyug.png)

Dilim döndüğümce ve öğrendiğim kadarıyla birşeyler aktarmaya çalıştım umarım faydalı olmuştur. Başka bir yazıda görüşmek dileğiyle…

https://medium.com/@ademolguner/core-3-0-ile-swagger-kullanımı-b80196fd8787
