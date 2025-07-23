# 🏥 Planification du Temps pour Clinique — Drag & Drop Scheduler

## 📌 Description du Projet

Ce projet consiste à développer une application web de planification des rendez-vous médicaux dans une clinique. Il permet aux utilisateurs (secrétaires, médecins, gestionnaires) de planifier, déplacer et gérer les créneaux horaires grâce à une interface **drag & drop intuitive**, conçue avec **Bootstrap**, et un backend robuste développé avec **.NET Core**.

---

## ⚙️ Technologies Utilisées

### Frontend
- HTML5, CSS3, JavaScript
- [Bootstrap 5](https://getbootstrap.com/)
- FullCalendar.js (ou une autre librairie de planning avec drag & drop)
- AJAX / Fetch API

### Backend
- ASP.NET Core (.NET 6 ou .NET 7)
- Entity Framework Core
- API RESTful
- SQL Server (ou SQLite)

---
<img width="2082" height="4461" alt="homme" src="https://github.com/user-attachments/assets/b18fbee9-5afd-49f7-956c-2bf61bab7e70" />


## 🎯 Fonctionnalités Clés

- 🔐 **Authentification sécurisée**
  - Inscription et connexion sécurisées selon le rôle : chef de service, médecin, cuisinier, etc.
  - Interface d’identification intuitive et protégée
<img width="2102" height="1152" alt="sinscrire" src="https://github.com/user-attachments/assets/ff767148-a52c-4587-804a-3fa451fbe615" />
<img width="2102" height="1152" alt="cobnnecter" src="https://github.com/user-attachments/assets/4236e8d3-ce5c-4ae3-9805-0f445548aa3b" />

- 👨‍⚕️ **Création de plannings dynamiques par le chef de service**
  - Définition des **postes de travail** (médecin, infirmier, cuisinier, etc.)
  - Chaque poste inclut :
    - 📅 **Date**
    - 🕗 **Heure de début et de fin**
    - ⏰ **Session** : Matin / Après-midi / Nuit
    - 📂 **Type de période** : Journée normale / Hiver / Ramadan
  - Paramétrage des **jours de repos** et des **heures supplémentaires**
<img width="2103" height="1152" alt="poste setting" src="https://github.com/user-attachments/assets/510f03c3-e7f2-4fdd-9067-2fbaa4506264" />

- 📆 **Consultation hebdomadaire personnalisée**
  - Chaque utilisateur accède à son emploi du temps par semaine
  - Visualisation claire des postes, horaires et sessions assignés
  - Indication des jours de repos et des sessions spéciales (ex : Ramadan)
<img width="2155" height="1152" alt="affiche emploi" src="https://github.com/user-attachments/assets/2daa85a5-08e3-4d68-9026-08df755b341b" />

- 🖱️ **Construction du planning par Drag & Drop**
  - Glisser-déposer pour planifier les équipes sur la semaine sélectionnée
  - Adaptation rapide en cas de modification ou d’absence
  - Mise à jour dynamique du calendrier
<img width="2102" height="1152" alt="creation demplois" src="https://github.com/user-attachments/assets/3661bcbf-5a83-4466-8cf7-a61dd731e50f" />

- 🛠️ **Semaine paramétrable et contextuelle**
  - Possibilité de définir des semaines spécifiques selon :
    - La période (normale, hiver, Ramadan)
    - Les contraintes du service (heures réduites, surcharge, etc.)

- 🔔 **Notifications & alertes **
  - Avertissement en cas de modification de planning
  - Envoi automatique par email ou dans l’interface web

