// Site içi genel JS fonksiyonları

// 1. Yetenek barlarını animasyonla doldur (Sayfa yüklendiğinde)
document.addEventListener("DOMContentLoaded", function () {
    let progressBars = document.querySelectorAll('.progress-bar');
    progressBars.forEach(function (bar) {
        let width = bar.getAttribute('aria-valuenow');
        bar.style.width = width + '%';
    });
});

// 2. Basit element gizleme/gösterme animasyonu (Hizmetler sayfası için kullanılabilir)
function toggleElement(elementId) {
    let element = document.getElementById(elementId);
    if (element.style.display === "none" || element.style.display === "") {
        element.style.display = "block";
        element.style.animation = "fadeIn 0.5s";
    } else {
        element.style.display = "none";
    }
}

// 3. Form doğrulama (İletişim sayfası için)
function validateContactForm() {
    let name = document.getElementById("Name").value;
    let email = document.getElementById("Email").value;
    let message = document.getElementById("Message").value;

    if (name.trim() === "" || email.trim() === "" || message.trim() === "") {
        alert("Lütfen tüm zorunlu alanları doldurun!");
        return false;
    }
    return true;
}
