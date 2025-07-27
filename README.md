
<h1 align="center">🔐 Log-in System (C# Console Application)</h1>

<p align="center">
  <img src="https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" />
  <img src="https://img.shields.io/badge/Platform-.NET%20Framework-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/Version-1.0-blue?style=for-the-badge" />
</p>

---

## 📖 Description
**Log-in System** is a **C# Console Application** designed to manage users in a simple and efficient way.  
It provides features for **user registration, login, data viewing, updating, account deletion, and displaying all usernames** in a clean interface.  

---

## ✨ Key Features
- 🎨 **Beautiful Console UI** with centered text (CenterText).
- 🔑 **User registration** with built-in input validation.
- 🔐 **Secure login** by verifying username and password.
- 📋 **View and update user data** with multiple fields.
- ❌ **Delete accounts** permanently.
- 📜 **Display all usernames** sorted alphabetically.
- 🖋️ **Store user data** in a simple text file (`UserData.txt`).

---

## 📸 Screenshots (with design)

### 1️⃣ Welcome Screen
![Welcome](https://github.com/youssif-Hy/Log-in-System/blob/main/assets/welcome.png?raw=true)

### 2️⃣ Login Menu
![Login Menu](Log-inSystem_pro/assets/login-menu.png)

### 3️⃣ Register Screen
![Register](Log-inSystem_pro/assets/register.png)

### 4️⃣ Main Menu (after login)
![Main Menu](Log-inSystem_pro/assets/main-menu.png)

---

## 🚀 How to Run

1. Clone or download the repository:
   ```bash
   git clone https://github.com/username/Log-in-System.git
   cd Log-in-System
   dotnet run
   ```
2. The program will automatically create the `UserData.txt` file when needed to store user data.

---

## 📦 Example: `UserData.txt`

```
username,password,name,phone,email,dateOfBirth,gender,hobbies
ahmed123,12345678,Ahmed Ali,01012345678,ahmed@gmail.com,01/01/2000,MALE,Reading
```

---

## 🛠️ Technical Details

- **Programming Language:** C# (Console Application)
- **Data Storage:** `UserData.txt` (Text File)
- **Input Validation:**  
  - Password length: 8–18 characters  
  - Valid email address with `@` and domain  
  - Phone number: 11 digits starting with (010 - 011 - 012 - 015)  
  - Alphabetical sorting of usernames  

---

## 🗂️ Project Structure

```
Log-in-System/
│
├── Program.cs           # Main source code
├── UserData.txt         # User data file
├── assets/              # Screenshots folder for README
│   ├── welcome.png
│   ├── login-menu.png
│   ├── register.png
│   └── main-menu.png
└── README.md            # Documentation
```

---

## 👨‍💻 Author

- **Youssef Harby**  
- 📧 Email: youssif2371@gmail.com  
- 🌐 [GitHub Profile](https://github.com/youssif-Hy)

---

<p align="center">⭐ If you like this project, don't forget to star the repository ⭐</p>
