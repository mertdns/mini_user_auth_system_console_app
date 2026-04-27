# Console App User Auth

Bu proje, basit bir kullanıcı kimlik doğrulama sistemi içeren bir .NET konsol uygulamasıdır. Kullanıcılar giriş yapabilir, menü üzerinden çeşitli işlemler gerçekleştirebilir.

## Özellikler

- **Kullanıcı Girişi**: Kullanıcı adı ve şifre ile giriş yapma.
- **Rol Tabanlı Erişim**: Admin ve normal kullanıcı rolleri.
- **Menü Seçenekleri**:
  - Tüm kullanıcı bilgilerini görüntüleme.
  - Aktif kullanıcı bilgilerini görüntüleme.
  - Kullanıcı silme (sadece admin için).
- **Güvenlik**: Şifre doğrulama ve rol kontrolü.

## Gereksinimler

- .NET 8.0 SDK veya üzeri.

## Kurulum

1. Projeyi klonlayın veya indirin.
2. Terminalde proje dizinine gidin.
3. Aşağıdaki komutu çalıştırın:

   ```
   dotnet run
   ```

## Kullanım

1. Programı çalıştırdığınızda, giriş ekranı görünecektir.
2. Kullanıcı adı ve şifrenizi girin (örnek: mert/123, admin/123).
3. Giriş başarılı olursa, ana menüye yönlendirileceksiniz.
4. Menüden seçenekleri seçin:
   - 1: Tüm kullanıcı bilgilerini görüntüle.
   - 2: Çıkış.
   - 3: Aktif kullanıcı bilgilerini görüntüle.
   - 4: Kullanıcı sil (sadece admin için).

## Kod Yapısı

- `Program.cs`: Ana program dosyası, giriş ve menü mantığını içerir.
- `User` sınıfı: Kullanıcı modelini ve ilgili metodları tanımlar.

## Örnek Kullanıcılar

- mert / 123 (normal kullanıcı)
- admin / 123 (admin)
- ali / 1234 (normal kullanıcı)

## Katkıda Bulunma

Bu proje eğitim amaçlıdır. Geliştirmeler için pull request gönderebilirsiniz.