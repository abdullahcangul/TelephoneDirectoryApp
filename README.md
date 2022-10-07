
# Telefon Rehberi Uygulamsı

Proje 2 microservis barındıran telefon rehberi uygulamasıdır.Kullanıcı Kişisel bilgilerini kayıt edip adres bazlı rapor oluşturabilmektedir. Report servis rapor oluşturmaktadır. Person servis işe kullanıcı bilgilerini kaydetmek için kullanılır.





## Kullanılan Teknolojiler ve Mimariler

- Clean Architecture
- Microservice
- MediaR
- RabitMq
- Entity Framework
- .Net 6
- PostgreSql
- Rest Api
- AutoMapper
- Polly

## Microservisler
Person servis : Kullanıcı sisteme kullanıcı bilgilerinin kaydetdiği servistir.

Report servis : Kullanıcının rapor oluşturma işteği bıraktığı ve rapor hazır olunca görüntüleye bildiği servistir.



## API Kullanımı

#### Tüm raporları getir

```http
  GET /api/reports/GetReports
```


#### Tüm raporları detayları ile getirir.

```http
  GET /api/reports/GetReportsWithReportDetail
```


#### Rapor oluşturma isteğinde bulunur

```http
  POST /api/reports/CreateReport
```


#### Kişi detayları ile kişi listesi getirir.

```http
  GET /api/Persons/PersonWithContacts
```

#### Kişi Ekler

```http
  Post /api/Persons/CreatePerson
```


#### Kişiyi ve ilişkili kayıtlarla sil

```http
  Delete /api/Persons/DeletePerson
```


#### Kişi detay Ekle

```http
  Post /api/Contacts/CreateContact
```


#### Kişiyi detayı sil

```http
  Delete /api/Contacts/DeleteContact
```

  
## Yükleme 

Projenin kullanılabilmesi için

#### postgresql, RabbitMq yüklenmelidir.

    postrasql default şifre 1234 yada appsetting güncellenmelidir.
