const lenguage = document.getElementById("lenguage");
const home = document.getElementById("home");
const productions = document.getElementById("productions");
const contactUs = document.getElementById("contact-us");
const aboutUs = document.getElementById("about-us");
const configuration = document.getElementById("configuration");
const labelLenguage = document.getElementById("label-lenguage");
const labelTheme = document.getElementById("label-theme");
const theme = document.getElementById("theme");
const news = document.getElementById("news");
const titleOne = document.getElementById("title-one");
const summaryOne = document.getElementById("summary-one");
const titleSecond = document.getElementById("title-second");
const summarySecond = document.getElementById("summary-second");
const titleThird = document.getElementById("title-third");
const summaryThird = document.getElementById("summary-third");
const developed = document.getElementById("developed");

const body = document.querySelector("body");
const header = document.querySelector("header");
const footer = document.querySelector("footer");
const dropdownContent = document.getElementById("dropdown-content");
const containerCards = document.getElementById("container-cards");

function changeLenguage() {
  if (lenguage.textContent === "ESPAÑOL") {
    lenguage.textContent = "ENGLISH";
    home.textContent = "INICIO";
    productions.textContent = "PRODUCCIONES";
    contactUs.textContent = "CONTACTANOS";
    aboutUs.textContent = "SOBRE NOSOTROS";
    configuration.textContent = "CONFIGURACIÓN";
    labelLenguage.textContent = "LENGUAJE A";
    labelTheme.textContent = "TEMA A";
    news.textContent = "NOVEDADES";
    titleOne.textContent = "MAKE aventuras - Especial Fiestas";
    summaryOne.textContent =
      "Se acerca fin de año, todos queremos celebrar y sobre todo pasarlo bien, por eso con esta animación os recordamos no utilizar fuegos artificiales.";
    titleSecond.textContent = "MAKE aventuras - Especial Halloween";
    summarySecond.textContent =
      "Finalmente llega el día en que todo lo que da miedo es aceptado y todos esperan con ansias experimentar el terror.";
    titleThird.textContent = "Fernet Branca - Arte Unico Concurso";
    summaryThird.textContent =
      "Con esta animación participamos por primera vez en un concurso con una temática, no ganamos pero la experiencia fue increíble.";
    developed.textContent = "desarrollado por Matias Aguilar";

    if (theme.textContent === "DARK") {
      theme.textContent = "OSCURO";
    }
  } else {
    lenguage.textContent = "ESPAÑOL";
    home.textContent = "HOME";
    productions.textContent = "PRODUCTIONS";
    contactUs.textContent = "CONTACT US";
    aboutUs.textContent = "ABOUT US";
    configuration.textContent = "CONFIGURATION";
    labelLenguage.textContent = "LENGUAGE TO";
    labelTheme.textContent = "THEME TO";
    news.textContent = "NEWS";
    titleOne.textContent = "MAKE adventures - Special Holidays";
    summaryOne.textContent =
      "The end of the year is approaching, we all want to celebrate and above all have a good time, so with this animation we remind you not to use fireworks.";
    titleSecond.textContent = "MAKE adventures - Special Halloween";
    summarySecond.textContent =
      "Finally comes the day when everything scary is accepted and everyone looks forward to experiencing terror.";
    titleThird.textContent = "Fernet Branca - Unique Art contest";
    summaryThird.textContent =
      "With this animation we participated for the first time in a contest with a theme, we did not win but the experience was incredible.";
    developed.textContent = "developed by Matias Aguilar";

    if (theme.textContent === "OSCURO") {
      theme.textContent = "DARK";
    }
  }
}

function changeTheme() {
  if (theme.textContent === "DARK" || theme.textContent === "OSCURO") {
    body.classList.add("dark-body");
    header.classList.add("dark-theme");
    footer.classList.add("dark-theme");
    news.style.backgroundColor = "rgb(40, 40, 40)";
    containerCards.style.border = "5px solid rgb(40, 40, 40)";
    home.classList.replace("nav-item", "dark-item");
    productions.classList.replace("nav-item", "dark-item");
    contactUs.classList.replace("nav-item", "dark-item");
    aboutUs.classList.replace("nav-item", "dark-item");
    configuration.classList.replace("dropbtn", "dark-btn");
    lenguage.classList.replace("dropbtn", "dark-btn");
    theme.classList.replace("dropbtn", "dark-btn");
    dropdownContent.classList.replace("dropdown-content", "dark-dropdown");

    theme.textContent = "COLOR";
  } else {
    body.classList.remove("dark-body");
    header.classList.remove("dark-theme");
    footer.classList.remove("dark-theme");
    news.style.backgroundColor = "rgb(113, 19, 202)";
    containerCards.style.border = "5px solid rgb(113, 19, 202)";
    home.classList.replace("dark-item", "nav-item");
    productions.classList.replace("dark-item", "nav-item");
    contactUs.classList.replace("dark-item", "nav-item");
    aboutUs.classList.replace("dark-item", "nav-item");
    configuration.classList.replace("dark-btn", "dropbtn");
    lenguage.classList.replace("dark-btn", "dropbtn");
    theme.classList.replace("dark-btn", "dropbtn");
    dropdownContent.classList.replace("dark-dropdown", "dropdown-content");

    if (lenguage.textContent === "ESPAÑOL") {
      theme.textContent = "DARK";
    } else {
      theme.textContent = "OSCURO";
    }
  }
}

lenguage.addEventListener("click", changeLenguage);
theme.addEventListener("click", changeTheme);
