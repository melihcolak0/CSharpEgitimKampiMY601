# :gem:C# Eğitim Kampı (#601)
Bu repository, Murat Yücedağ'ın C# Eğitim Kampı isimli eğitiminin #601 modülünü içermektedir.

## :pushpin: Proje 1 -> MongoDB
Bu projede farklı bir veri tabanı kullanarak CRUD (Create, Read, Update, Delete) işlemlerini tamamlamak istedim. Bunun için MongoDB'nin güzel bir tercih olabileceğine inanıyorum. MongoDB, NoSQL (Not Only SQL) veri tabanları arasında popüler bir açık kaynaklı veritabanı yönetim sistemidir. Geleneksel ilişkisel veritabanlarından farklı olarak, MongoDB, verileri JSON benzeri belgeler (dokümanlar) şeklinde saklar. Bu, esnek bir veri modeli sağlar ve yapılandırılmış, yarı yapılandırılmış veya yapılandırılmamış verilerle çalışmayı kolaylaştırır. MongoDB kullanarak ve folder structer'a önem göstererek ilk olarak Ekleme işlemini yaptım.

## :pushpin: Proje 1 -> MongoDB CRUD İşlemleri
Bir önceki projede oluşturmuş olduğum CustomerOperations sınıfında Ekleme işlemini yapmıştım. Sırada Listeleme, Silme, Gümcelleme ve Id'ye Göre Getirme işlemlerini yapmak vardı. Bu işlemlerin sıralamaları benzer şekildedir. Örneğin Update işleminde öncelikle MongoDB bağlantısı oluşturuyoruz, devamında kullanacağımız Müşteri koleksiyonuna erişiyoruz, ardından güncellenecek kaydı seçmek için bir filtre oluşturuyoruz, sonrasında güncellenecek alanları tanımlıyoruz, son olarak da filtreye uyan kaydı, güncellenmiş değerlerle değiştiriyoruz. Diğer bir örnek olarak listeleme işleminde, yine ilk olarak MongoDB bağlantı nesnesini oluşturuyoruz, ardından yine Müşteri koleksiyonuna erişiyoruz, devamında koleksiyondaki tüm belgeleri alıyoruz, Customer tipinde bir liste oluşturuyoruz, her bir belge Customer nesnesine dönüştürülüyor (Dönüştürme sırasında MongoDB belgesindeki alanlar (c["CustomerName"] gibi), Customer sınıfının özelliklerine atanır.) ve son olarak liste geri döndürülür.


