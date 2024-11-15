# .NET Ürün Yönetim Sistemi  

Bu proje, **SQL Server** üzerinde bir veritabanı oluşturarak, ürün bilgilerini CRUD (Create, Read, Update, Delete) işlemleriyle yönetmek için geliştirilmiştir. Projede ayrıca **.NET Core API** ile ürünlerin listelenmesi, silinmesi ve tek bir ürünün getirilmesi gibi işlemler gerçekleştirilmiştir. Proje kapsamında **JWT tabanlı kimlik doğrulama** uygulanmıştır.  

## Proje Özellikleri  

### 1. Veritabanı  
- **Ürün** adında bir tablo oluşturulmuştur.  
  - Tablo Alanları:  
    - `Adı`  
    - `Kodu`  
    - `Fiyatı`  
    - `Oluşturma Tarihi`  
    - `Resmi`  

### 2. Proje Katmanları  
Proje aşağıdaki katmanlardan oluşmaktadır:  
- **DataAccess**:  
  - Entity Framework Core ile SQL Server üzerinde CRUD işlemleri gerçekleştirilmiştir.  
  - **DbContext** sınıfı kullanılmıştır.  
- **Business**:  
  - İş kuralları ve veri işlemleri bu katmanda yönetilmiştir.  
- **API**:  
  - Ürünlerin listelenmesi, tek bir ürünün getirilmesi ve silinmesi işlemleri yapılmıştır.  
  - JWT tabanlı kimlik doğrulama ile API güvenliği sağlanmıştır.  

### 3. CRUD İşlemleri  
HTML tabanlı bir kullanıcı arayüzü aracılığıyla:  
- Ürün listeleme,  
- Yeni ürün ekleme,  
- Mevcut ürün güncelleme,  
- Ürün silme işlemleri yapılabilmektedir.  

### 4. API Özellikleri  
- **Listeleme**: Tüm ürünlerin listesi API üzerinden döndürülmektedir.  
- **Tek Ürün Getirme**: Belirtilen ürün ID’sine göre detay bilgisi API'den alınabilmektedir.  
- **Silme**: Belirtilen ID ile ürün silinmektedir.  

### 5. JWT Tabanlı Kimlik Doğrulama  
- API'ye erişim için **JSON Web Token (JWT)** doğrulaması yapılmaktadır.  
- Token olmadan API'ye erişim sağlanamamaktadır.  

## Kurulum  

1. **Veritabanı Oluşturma**:  
   - SQL Server üzerinde projeye uygun bir veritabanı oluşturun.  
   - **DataAccess** katmanındaki `DbContext` sınıfında bağlantı dizesini (`connection string`) güncelleyin.  

2. **Projeyi Çalıştırma**:  
   - Projeyi Visual Studio veya .NET CLI ile çalıştırabilirsiniz.  

3. **API Kullanımı**:  
   - API'ye isteklerde bulunmadan önce bir **JWT Token** almanız gerekmektedir.  
   - API'ye erişim için her istekte `Authorization: Bearer <TOKEN>` başlığını ekleyin.  

## Teknolojiler ve Araçlar  
- **.NET Core**  
- **Entity Framework Core**  
- **SQL Server**  
- **JWT Authentication**  
- **Razor Page**  

## Opsiyonel: Ekstralar  
- **Repository Pattern** ve **Unit of Work Pattern** kullanılmıştır.  
- Projede **Service Management** uygulanmıştır.  

## API Örnekleri  

- **Listeleme**  
  `GET /api/products`  

- **Tek Ürün Getirme**  
  `GET /api/products/{id}`  

- **Silme**  
  `DELETE /api/products/{id}`  

Herhangi bir sorunuz veya öneriniz için benimle iletişime geçebilirsiniz.  
