Core 3.0 ile Swagger Kullanmak 

Merhabalar bir süredir kullanmakta olduğum swagger hakkında öğrendiğim kadarıyla, kullanım ve kullanım örnekleri ile farklı bir yazı ile devam etmek istiyorum. Swagger nedir?, nasıl kurulur, nasıl kullanılır ne işimize yarayacak gibi soruların cevaplarını bulmaya çalışacağız.


Swagger’a geçmeden önce API hakkında birkaç şey söylemek gerekiyor. API’ler artık günlük projelerimizin olmazsa olmazı haline gelmeye başladı özellikle mobil uygulamaların artması ile hem web, hem windows hemde mobil uygulamalar için ortak bir katman olan API’ler daha fazla karşılaşmaya başladık. API’lerin rest , soap gibi detaylarına girmeyeceğim amacım swagger’i etkin olarak nasıl kullanırız olacaktır.


API hizmeti verdiğimiz yada aldığımız durumlarda birde dökümantasyon gibi önemli ve bir o kadarda iş yükü beraberinde gelmekte, servislere ait hangi method hangi parametreler ile istek alıyordu, istek objesine eklenen ya da çıkarılan bir nesne oldumu, response içerisinde neler değişti gibi birçok soru beraberinde gelmekte. Her güncelleme durumunda dökümanı da aynı şekilde güncel tutmak gerekmektedir, işte tam da burada SWAGGER imdadımıza yetişiyor.

Swagger ?

Swagger aslında bahsetmiş olduğum API hizmetleri için bir dökümantasyondur. Swagger RestApi’ler için bir nevi arayüz sağlamaktadır. Entity, DataAcces ve Business katmanlarını hazır olduğunu düşünelim ve API projesinide yazdık eee ne var bunda burada WebUI katmanını yazmadan veya Mobil katmanlarını yazmadan sağlama da yapabileceğiz demek! O nasıl oluyor ki :) Şimdi Swagger ile API’lerin testlerini çalıştırarak testlerin başarılı olup olmadığını backend tarafında olası hataları arayüz katmanını yazmadan da tespit edebileceğimiz anlamına geliyor. Kulağa hoş geliyor gibi.
    
Ufak bir örnek üzerinden anlatmaya çalışacağım.

* Bir adet Core 3.0 WebAPI projesi oluşturacağız,
* Bir adet api controller (StudentsController) oluşturacağız,
* Bir adet de Student nesnemiz oluyor olacak,
* StudentsController içerisinde Get,Post,Put,Delete işlemlerine örnek olması amacıyla birer adet method oluşturacağız,
* appsettings.json dosyasında swagger ayarlaması yapıp GetSection ile bu ayarları okuyacağız,
* ProducesResponseType ile swagger’ı biraz daha kullanıcı dostu haline getirip zenginleştireceğiz.
* Method commentlerinin swagger da görüntülenmesi için optimizasyon yapacağız.
* pragma warning disable ile uyarıların nasıl dikkate alınmayacağı gibi ufak tefek işimizi kolaylaştıracak ayarlar yapıyor olacağız.


[https://medium.com/@ademolguner/core-3-0-ile-swagger-kullan%C4%B1m%C4%B1-b80196fd8787] erişebilirsiniz
