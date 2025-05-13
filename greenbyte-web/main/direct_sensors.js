// Sayfa yüklenir yüklenmez çalış
// Global değişkenler
let lastDataUpdateTime = null; // Son başarılı veri güncelleme zamanı

document.addEventListener('DOMContentLoaded', function() {
    console.log("Basit sensör gösterim scripti çalışıyor...");
    
    // Local storage'dan son güncelleme zamanını al (varsa)
    const savedUpdateTime = localStorage.getItem('lastUpdateTime');
    if (savedUpdateTime) {
        lastDataUpdateTime = new Date(parseInt(savedUpdateTime));
        // Kaydedilmiş son veri saatini göster
        displayLastUpdateTime(lastDataUpdateTime);
        console.log("Son kayıtlı güncelleme zamanı yüklendi:", lastDataUpdateTime);
    }
    
    // Sayfa yüklenirken cihaz durumunu hemen kontrol et
    checkDeviceStatus();
    
    // Geçerli zamanı güncelle - sayfanın yüklenmesinden hemen sonra
    updateCurrentTime();
    
    // Hemen bir veri çekelim
    loadAndDisplaySensors();
    
    // Her 15 saniyede bir sensör verilerini çek
    setInterval(loadAndDisplaySensors, 15000);
    
    // Her 1 saniyede bir saati güncelle
    setInterval(updateCurrentTime, 1000);
    
    // Her 5 saniyede bir cihaz durumunu kontrol et
    setInterval(checkDeviceStatus, 5000);
});

// Ana veri çekme ve gösterme fonksiyonu
function loadAndDisplaySensors() {
    console.log("Sensör verileri çekiliyor...");
    
    fetch('../api/veri_getir.php?tip=son_veriler&t=' + new Date().getTime())
        .then(response => {
            if (!response.ok) {
                throw new Error('API yanıtı başarısız: ' + response.status);
            }
            return response.json();
        })
        .then(data => {
            console.log("API veri sonucu:", data);
            
            if (data.durum === 'basarili' && hasValidSensorData(data.veriler)) {
                // Geçerli zamanı son veri güncelleme saati olarak kaydet
                const now = new Date();
                lastDataUpdateTime = now;
                
                // Güncellenmiş zamanı hem göster hem de kaydet
                displayLastUpdateTime(lastDataUpdateTime);
                localStorage.setItem('lastUpdateTime', lastDataUpdateTime.getTime().toString());
                
                // Cihaz durumunu güncelle - veritabanından gelen cihaz durumunu kullan
                if (data.veriler.cihaz_durumu) {
                    updateDeviceStatus(data.veriler.cihaz_durumu === 'cevrimici');
                } else {
                    updateDeviceStatus(true); // Varsayılan olarak çevrimiçi
                }
                
                // Sistem durumunu güncelle
                if (data.veriler.sistem_durumu) {
                    updateSystemStatus(data.veriler.sistem_durumu);
                }
                
                // Sensör değerlerini göster
                displaySensorValues(data.veriler);
            } else {
                console.error("API hatası veya geçersiz veri:", data.mesaj || "Veri bulunamadı");
                // Cihaz durumunu güncelle - hata durumunda
                checkDeviceStatus();
            }
        })
        .catch(error => {
            console.error("Veri çekme hatası:", error);
            // Hata durumunda cihaz durumunu güncelle
            checkDeviceStatus();
        });
}

// Gelen sensör verilerinin geçerli olup olmadığını kontrol et
function hasValidSensorData(data) {
    // En az bir sensör değeri doğru şekilde dolu mu kontrol et
    return (
        (data.sicaklik && data.sicaklik !== "--") ||
        (data.nem && data.nem !== "--") ||
        (data.isik_seviyesi && data.isik_seviyesi !== "--") ||
        (data.toprak_nemi && data.toprak_nemi !== "--") ||
        (data.su_seviyesi && data.su_seviyesi !== "--")
    );
}

// Son güncelleme zamanını göster
function displayLastUpdateTime(time) {
    if (time) {
        const hours = time.getHours().toString(); // başta sıfır olmadan
        const minutes = time.getMinutes().toString().padStart(2, '0');
        const seconds = time.getSeconds().toString().padStart(2, '0');
        const timeString = `${hours}:${minutes}:${seconds}`;
        updateElement('#last-update strong', timeString);
    }
}

// Sensör değerlerini UI'a uygula
function displaySensorValues(data) {
    console.log("Sensör değerleri uygulanıyor:", data);
    
    // Sıcaklık
    if (data.sicaklik && data.sicaklik !== "--") {
        updateElement('#temperature-value', data.sicaklik + '°C');
        updateElement('#current-temperature', data.sicaklik + '°C');
        // Durum sınıfını da ayarla
        updateStatusClass('#temperature-value', data.durum_sicaklik);
    }
    
    // Nem
    if (data.nem && data.nem !== "--") {
        updateElement('#humidity-value', data.nem + '%');
        updateElement('#current-humidity', data.nem + '%');
        updateStatusClass('#humidity-value', data.durum_nem);
    }
    
    // Işık
    if (data.isik_seviyesi && data.isik_seviyesi !== "--") {
        updateElement('#light-value', data.isik_seviyesi + '%');
        updateElement('#current-light', data.isik_seviyesi + '%');
        updateStatusClass('#light-value', data.durum_isik);
    }
    
    // Toprak Nemi
    if (data.toprak_nemi && data.toprak_nemi !== "--") {
        updateElement('#soil-moisture-value', data.toprak_nemi + '%');
        updateElement('#soil-gauge-value', data.toprak_nemi + '%');
        updateStatusClass('#soil-moisture-value', data.durum_toprak);
        
        // Gauge değerini ayarla
        const gaugeElement = document.querySelector('#soil-gauge .gauge-value');
        if (gaugeElement) {
            gaugeElement.style.height = data.toprak_nemi + '%';
        }
    }
    
    // CO2
    if (data.co2 && data.co2 !== "---") {
        updateElement('#co2-value', data.co2 + ' ppm');
        updateElement('#current-co2', data.co2 + ' ppm');
        updateStatusClass('#co2-value', data.durum_hava);
    }
    
    // Su Seviyesi
    if (data.su_seviyesi && data.su_seviyesi !== "--") {
        updateElement('#water-level-value', data.su_seviyesi + '%');
        updateElement('#water-percentage', data.su_seviyesi + '%');
        updateStatusClass('#water-level-value', data.durum_su);
        
        // Su seviyesi göstergesini ayarla
        const waterLevelElement = document.querySelector('#water-panel .water-level');
        if (waterLevelElement) {
            waterLevelElement.style.height = data.su_seviyesi + '%';
        }
    }
    
    // Son güncelleme zamanını API'den gelen değerle güncelle
    if (data.son_guncelleme) {
        updateElement('#last-update strong', data.son_guncelleme);
    } else {
        const now = new Date();
        const hours = now.getHours().toString(); // başta sıfır olmadan
        const minutes = now.getMinutes().toString().padStart(2, '0');
        const seconds = now.getSeconds().toString().padStart(2, '0');
        const timeString = `${hours}:${minutes}:${seconds}`;
        updateElement('#last-update strong', timeString);
    }
    
    console.log("Sensör değerleri güncellendi");
}

// Eleman değerini güncelleme yardımcı fonksiyonu
function updateElement(selector, value) {
    const element = document.querySelector(selector);
    if (element) {
        element.textContent = value;
    } else {
        console.warn(`Eleman bulunamadı: ${selector}`);
    }
}

// Durum sınıfını ayarlama fonksiyonu
function updateStatusClass(valueSelector, status) {
    const element = document.querySelector(valueSelector);
    if (element) {
        const statusElement = element.nextElementSibling;
        if (statusElement && statusElement.classList.contains('stat-status')) {
            // Önce tüm durum sınıflarını kaldır
            statusElement.classList.remove('normal', 'warning', 'danger');
            
            // Duruma göre sınıf ekle
            switch (status) {
                case 'normal':
                    statusElement.classList.add('normal');
                    statusElement.textContent = 'Normal';
                    break;
                case 'dusuk':
                    statusElement.classList.add('warning');
                    statusElement.textContent = 'Düşük';
                    break;
                case 'yuksek':
                    statusElement.classList.add('warning');
                    statusElement.textContent = 'Yüksek';
                    break;
                case 'kritik':
                    statusElement.classList.add('danger');
                    statusElement.textContent = 'Kritik';
                    break;
            }
        }
    }
}

// Mevcut zamanı güncelleme fonksiyonu
function updateCurrentTime() {
    const now = new Date();
    const hours = now.getHours().toString(); // başta sıfır olmadan
    const minutes = now.getMinutes().toString().padStart(2, '0');
    const seconds = now.getSeconds().toString().padStart(2, '0');
    
    // Saat formatı: SS:DD:SS
    const timeString = `${hours}:${minutes}:${seconds}`;
    
    // Tarih formatı: gün ay yıl
    const options = { day: 'numeric', month: 'long', year: 'numeric' };
    const dateString = now.toLocaleDateString('tr-TR', options);
    
    // Saat ve tarih elementlerini güncelle
    updateElement('#current-time', timeString);
    updateElement('#current-date', dateString);
}

// Cihaz durumunu kontrol et ve güncelle
function checkDeviceStatus() {
    // Son başarılı veri güncellemesi yok veya 45 saniyeden eski ise cihaz çevrimdışı
    const now = new Date();
    const offlineThreshold = 45 * 1000; // 45 saniye - ESP32'nin 15s döngüsü için 3 döngü tolerans
    
    if (!lastDataUpdateTime || (now - lastDataUpdateTime) > offlineThreshold) {
        updateDeviceStatus(false); // Çevrimdışı
    }
}

// Cihaz durumunu güncelle
function updateDeviceStatus(isOnline) {
    const deviceStatusElement = document.querySelector('#device-status strong');
    const deviceStatusIconElement = document.querySelector('#device-status i');
    
    if (deviceStatusElement) {
        if (isOnline) {
            deviceStatusElement.textContent = 'Çevrimiçi';
            deviceStatusElement.style.color = 'var(--secondary-green)';
            if (deviceStatusIconElement) {
                deviceStatusIconElement.style.color = 'var(--secondary-green)';
            }
        } else {
            deviceStatusElement.textContent = 'Çevrimdışı';
            deviceStatusElement.style.color = 'var(--red)';
            if (deviceStatusIconElement) {
                deviceStatusIconElement.style.color = 'var(--red)';
            }
        }
    }
}

// Sistem durumunu güncelle
function updateSystemStatus(status) {
    const systemStatusElement = document.querySelector('#system-status strong');
    const systemStatusIconElement = document.querySelector('#system-status i');
    
    if (systemStatusElement) {
        if (status === 'aktif') {
            systemStatusElement.textContent = 'Aktif';
            systemStatusElement.style.color = 'var(--secondary-green)';
            if (systemStatusIconElement) {
                systemStatusIconElement.style.color = 'var(--secondary-green)';
            }
        } else {
            systemStatusElement.textContent = 'Beklemede';
            systemStatusElement.style.color = 'var(--yellow)';
            if (systemStatusIconElement) {
                systemStatusIconElement.style.color = 'var(--yellow)';
            }
        }
    }
}