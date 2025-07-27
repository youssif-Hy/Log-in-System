using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;

namespace Log_in_System_pro
{
    internal class Program
    {
        //تعريف اسم الملف الذي سيتم تخزين بيانات المستخدمين فيه في متغير ثابت
        static string path = "UserData.txt";
        // دالة CenterText تقوم بجعل النص في وسط الشاشة
        static string CenterText(string text)
        {
            int padding = (Console.WindowWidth - text.Length) / 2;
            return new string(' ', Math.Max(padding, 0)) + text;

        }
        static void Main(string[] args)
        {
            // تعيين ترميز الإخراج إلى UTF-8 لدعم الأحرف العربية والرموز الخاصة
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // عرض رسالة الترحيب
            DisplayWelcomeMessage();
            // عرض قائمة تسجيل الدخول
            DisplayLoginMenu();
        }
        // دالة DisplayWelcomeMessage تقوم بعرض رسالة ترحيب للمستخدم
        static void DisplayWelcomeMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n");
            Console.WriteLine(CenterText("██╗░░░░░░█████╗░░██████╗░░░░░░░██╗███╗░░██╗"));
            Console.WriteLine(CenterText("██║░░░░░██╔══██╗██╔════╝░░░░░░░██║████╗░██║"));
            Console.WriteLine(CenterText("██║░░░░░██║░░██║██║░░██╗░█████╗██║██╔██╗██║"));
            Console.WriteLine(CenterText("██║░░░░░██║░░██║██║░░╚██╗╚════╝██║██║╚████║"));
            Console.WriteLine(CenterText("███████╗╚█████╔╝╚██████╔╝░░░░░░██║██║░╚███║"));
            Console.WriteLine(CenterText("╚══════╝░╚════╝░░╚═════╝░░░░░░░╚═╝╚═╝░░╚══╝"));
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(CenterText("Welcome to the Log-in System!"));
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(CenterText("Press any key to continue..."));
            Console.ReadKey();
        }
        // دالة DisplayLoginMenu تقوم بعرض قائمة تسجيل الدخول
        static void DisplayLoginMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(CenterText("Log-in Menu"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Please select an option: ");
            Console.ForegroundColor = ConsoleColor.White;
            int option;
            //loop للتأكد من إدخال المستخدم خيار صحيح
            while (true)
            {
                // رسالة خطأ في حالة إدخال غير صحيح
                string errorMessage = "Invalid input, please enter a number between 1 and 3.";
                // تعيين موضع المؤشر في الشاشة
                Console.SetCursorPosition(24, 4);
                // قراءة إدخال المستخدم والتحقق من صحته
                option = ValidateInput(Console.ReadLine(), 24, 4, 0, 5);
                // إذا كان الخيار غير صحيح، عرض رسالة الخطأ
                if (option != 1 && option != 2 && option != 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    WriteSlow(errorMessage, 20, 0, 5);
                    Console.ForegroundColor = ConsoleColor.White;
                    space(option.ToString(), 24, 4);
                }
                // إذا كان الإدخال صحيحًا، الخروج من الحلقة
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    space(errorMessage, 0, 5);
                    break;
                }
            }
            // تنفيذ الإجراء المناسب بناءً على خيار المستخدم
            switch (option)
            {
                case 1:
                    LogIn();
                    break;
                case 2:
                    Register();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            } 
        }
        // دالة LogIn تقوم بمعالجة عملية تسجيل الدخول
        static void LogIn()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            // ASCII Art لعرض عنوان تسجيل الدخول 
            Console.WriteLine(CenterText("╔══════════════════════════════════════════════════════╗"));
            Console.WriteLine(CenterText("║                       LOG IN                         ║"));
            Console.WriteLine(CenterText("║               --------------------------             ║"));
            Console.WriteLine(CenterText("║                                                      ║"));
            Console.WriteLine(CenterText("║   ➤ Enter Your Username :                            ║"));
            Console.WriteLine(CenterText("║   ➤ Enter Your Password :                            ║"));
            Console.WriteLine(CenterText("║                                                      ║"));
            Console.WriteLine(CenterText("║               [ Press ENTER to Submit ]              ║"));
            Console.WriteLine(CenterText("╚══════════════════════════════════════════════════════╝"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(59, 4); // اعادة تعيين موضع المؤشر لاسم المستخدم
            string user_name = Console.ReadLine();
            Console.SetCursorPosition(59, 5); // اعادة تعيين موضع المؤشر لكلمة المرور
            string password = Console.ReadLine();
            if (File.Exists(path)) // التحقق من وجود ملف بيانات المستخدمين
            {
                string[] lines = File.ReadAllLines(path);// قراءة جميع الأسطر من الملف
                foreach (string line in lines)
                {
                    // تقسيم السطر إلى أجزاء باستخدام الفاصلة كفاصل
                    string[] parts = line.Split(',');
                    // التحقق من تطابق اسم المستخدم وكلمة المرور
                    if (parts[0] == user_name && parts[1] == password)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        WriteSlow("Login successful!", 20, 0, 9);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("\nPress any key to continue to the main menu...");
                        Console.ResetColor();
                        Console.ReadKey();
                        DisplayMenu(line);
                    }
                }
                // إذا لم يتم العثور على تطابق، عرض رسالة خطأ
                if (lines.Length > 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    WriteSlow("Invalid username or password.", 20, 0, 9);
                    Console.ResetColor();
                    Console.WriteLine("Please try again or register if you don't have an account.");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Press any key to return to the login menu...");
                    Console.ReadKey();
                    DisplayLoginMenu();
                }
                if (lines.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    WriteSlow("No user data found. Please register first.", 20, 0, 9);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Press any key to return to the login menu.");
                    Console.ResetColor();
                    Console.ReadKey();
                    DisplayLoginMenu();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                WriteSlow("User data file not found.", 20, 0, 9);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Please register first.");
                Console.Write("Press any key to return to the login menu...");
                Console.ResetColor();
                Console.ReadKey();
                DisplayLoginMenu();
            }
        }
        // دالة DisplayMenu تقوم بعرض القائمة الرئيسية للمستخدم بعد تسجيل الدخول
        private static void DisplayMenu(string line)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            string[] parts = line.Split(','); 
            Console.WriteLine(CenterText($"Welcome {parts[2]} to the Main Menu!"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. View your data");
            Console.WriteLine("2. Update your data");
            Console.WriteLine("3. Delete your account");
            Console.WriteLine("4. view all usernames in the system");
            Console.WriteLine("5. Log out");
            Console.WriteLine("6. Exit");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Please select an option: ");
            int option;
            while (true)
            {
                string errorMessage = "Invalid input, please enter a number between 1 and 5.";
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(24, 7);
                option = ValidateInput(Console.ReadLine(), 24, 7, 0, 8);
                if (option < 1 || option > 6)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    WriteSlow(errorMessage, 20, 0, 8);
                    Console.ForegroundColor = ConsoleColor.White;
                    space(option.ToString(), 24, 7);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    space(errorMessage, 0, 8);
                    break;
                }
            }
            switch (option)
            {
                case 1:
                    ViewUserData(line);
                    break;
                case 2:
                    UpdateUserData(line);
                    break;
                case 3:
                    DeleteAccount(line);
                    break;
                case 4:
                    ViewAllUsernames(line);
                    break;
                case 5:
                    DisplayLoginMenu();
                    break;
            }
        }
        // دالة ViewAllUsernames تقوم بعرض جميع أسماء المستخدمين في النظام
        private static void ViewAllUsernames(string line1)
        {
            SortUsernames(); // Sort usernames before displaying them
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(CenterText("View All Usernames"));
            Console.WriteLine(CenterText("+================================================================================+"));
            Console.WriteLine(CenterText(" |                                 Usernames                                      |"));
            Console.WriteLine(CenterText("+================================================================================+"));
            string[] parts = new string[8];
            int yAxis = 4; 
            foreach (string line in File.ReadLines(path))
            {
                 parts = line.Split(',');
                if (parts.Length > 0)
                {
                    Console.SetCursorPosition(5, yAxis);
                    Console.Write(CenterText($"| ➤ {parts[0],-87}")); // Display username
                    Console.SetCursorPosition(100, yAxis++);
                    Console.WriteLine("|"); 
                }
            }
            Console.WriteLine(CenterText("+================================================================================+"));
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            DisplayMenu(line1);
        }
        // دالة SortUsernames تقوم بترتيب بيانات المستخدمين في الملف
        static void SortUsernames()
        {
            var lines = File.ReadAllLines(path).ToList();
            lines.Sort();
            File.WriteAllLines(path, lines);
        }
        // دالة DeleteAccount تقوم بحذف حساب المستخدم
        private static void DeleteAccount(string line)
        {
            Console.Clear();
            string[] parts = line.Split(',');
            // عرض واجهة المستخدم لحذف الحساب
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(CenterText("Delete Your Account"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Yes, delete my account");
            Console.WriteLine("2. No, go back to the main menu");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Please select an option (1-2): ");
            Console.ForegroundColor = ConsoleColor.White;
            int optionDelete;
            while (true)
            {
                string errorMessage = "Invalid input, please enter a number between 1 and 2.";
                Console.SetCursorPosition(30, 3);
                optionDelete = ValidateInput(Console.ReadLine(), 30, 3, 0, 4);
                if (optionDelete < 1 || optionDelete > 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    WriteSlow(errorMessage, 20, 0, 4);
                    Console.ForegroundColor = ConsoleColor.White;
                    space(optionDelete.ToString(), 30, 3);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    space(errorMessage, 0, 4);
                    break;
                }
            }
            // إذا اختار المستخدم حذف الحساب
            if (optionDelete == 1)
            {
                // حذف الحساب من ملف البيانات
                string[] lines = File.ReadAllLines(path);
                List<string> updatedLines = new List<string>();
                foreach (string line1 in lines)
                {
                    string[] parts1 = line.Split(',');
                    if (parts[0] != parts1[0]) // تحقق من أن اسم المستخدم لا يطابق المستخدم الحالي
                    {
                        updatedLines.Add(line); // حفظ السطر إذا لم يكن المستخدم الحالي
                    }
                }
                File.WriteAllLines(path, updatedLines);// كتابة الأسطر المحدثة إلى الملف
                Console.ForegroundColor = ConsoleColor.Green;
                WriteSlow("Your account has been deleted successfully.", 20, 0, 5);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(0, 6);
                Console.Write("\nPress any key to return to the login menu...");
                Console.ResetColor();
                Console.ReadKey();
                DisplayLoginMenu();
            }
            // إذا اختار المستخدم العودة إلى القائمة الرئيسية
            else
            {
                DisplayMenu(string.Join(",", parts));// العودة إلى القائمة الرئيسية
            }
        }
        // دالة UpdateUserData تقوم بتحديث بيانات المستخدم
        private static void UpdateUserData(string line)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(CenterText("Update Your Data"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Username");
            Console.WriteLine("2. Password");
            Console.WriteLine("3. Name");
            Console.WriteLine("4. Phone Number");
            Console.WriteLine("5. Email");
            Console.WriteLine("6. Date of Birth");
            Console.WriteLine("7. Gender");
            Console.WriteLine("8. Hobbies");
            Console.WriteLine("9. Back to Main Menu");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Please select the field you want to update (1-9): ");
            int optionUpdate;
            // حلقة للتحقق من إدخال المستخدم
            while (true)
            {
                string errorMessage = "Invalid input, please enter a number between 1 and 9.";
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(49, 10);
                optionUpdate = ValidateInput(Console.ReadLine(), 49, 10, 0, 11);
                if (optionUpdate < 1 || optionUpdate > 9)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    WriteSlow(errorMessage, 20, 0, 11);
                    Console.ForegroundColor = ConsoleColor.White;
                    space(optionUpdate.ToString(), 49, 10);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    space(errorMessage, 0, 11);
                    break;
                }
            }
            string optionString = "";
            // تعيين اسم الخيار بناءً على اختيار المستخدم
            switch (optionUpdate)
            {
                case 1:
                    optionString = "Username";
                    break;
                case 2:
                    optionString = "Password";
                    break;
                case 3:
                    optionString = "Name";
                    break;
                case 4:
                    optionString = "Phone Number";
                    break;
                case 5:
                    optionString = "Email";
                    break;
                case 6:
                    optionString = "Date of Birth";
                    break;
                case 7:
                    optionString = "Gender";
                    break;
                case 8:
                    optionString = "Hobbies";
                    break;
                case 9:
                    DisplayMenu(line);
                    break;
                
            }
            Console.Clear();
            // عرض واجهة المستخدم لتحديث البيانات
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(CenterText("+================================================================================+"));
            Console.WriteLine(CenterText("|                                 New Data                                       |"));
            Console.WriteLine(CenterText("+================================================================================+"));
            Console.WriteLine(CenterText("| ➤                   :                                                          |"));
            Console.WriteLine(CenterText("+================================================================================+"));
            Console.SetCursorPosition(23, 3);
            Console.Write(optionString);
            string newData;
            switch (optionUpdate)
            {
                case 1:
                    Console.SetCursorPosition(42, 3);
                    newData = ValidateUsername(Console.ReadLine(), 42, 3, 0, 5);
                    break;
                case 2:
                    Console.SetCursorPosition(42, 3);
                    newData = ValidatePassword(Console.ReadLine(), 42, 3, 0, 5);
                    break;
                case 3:
                    Console.SetCursorPosition(42, 3);
                    newData = ValiDateName(Console.ReadLine(), 42, 3, 0, 5);
                    break;
                case 4:
                    Console.SetCursorPosition(42, 3);
                    newData = ValiDatephoneNumber(Console.ReadLine(), 42, 3, 0, 5);
                    break;
                case 5:
                    Console.SetCursorPosition(42, 3);
                    newData = ValidateEmailForDoctors(Console.ReadLine(), 42, 3, 0, 5);
                    break;
                case 6:
                    Console.SetCursorPosition(42, 3);
                    newData = ValidateDateOfBirth(Console.ReadLine(), 42, 3, 0, 5);
                    break;
                case 7:
                    Console.SetCursorPosition(42, 3);
                    newData = ValidateGender(Console.ReadLine(), 42, 3, 0, 5);
                    break;
                case 8:
                    Console.SetCursorPosition(42, 3);
                    newData = ValidateHobbies(Console.ReadLine(), 42, 3, 0, 5);
                    break;
                default:
                    newData = "Invalid Option";
                    break;
            }
            // تحديث البيانات في ملف البيانات
            string[] parts = line.Split(','); 
            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts1 = lines[i].Split(',');
                if (parts[0] == parts1[0]) 
                {
                    parts[optionUpdate - 1] = newData; 
                    lines[i] = string.Join(",", parts); 
                    break;
                }
            }
            // كتابة البيانات المحدثة إلى الملف
            File.WriteAllLines(path, lines);
            Console.ForegroundColor = ConsoleColor.Green;
            WriteSlow("Your data has been updated successfully.", 20, 0, 5);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(0, 6);
            Console.Write("\nPress any key to return to the main menu...");
            Console.ReadKey();
            DisplayMenu(string.Join(",", parts));
        }
        // دالة ViewUserData تقوم بعرض بيانات المستخدم
        private static void ViewUserData(string line)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            // عرض واجهة المستخدم لعرض بيانات المستخدم
            Console.WriteLine(CenterText("+================================================================================+"));
            Console.WriteLine(CenterText("|                                 Your Data                                      |"));
            Console.WriteLine(CenterText("+================================================================================+"));
            Console.WriteLine(CenterText("| ➤ Username          :                                                          |"));
            Console.WriteLine(CenterText("| ➤ Password          :                                                          |"));
            Console.WriteLine(CenterText("| ➤ Name              :                                                          |"));
            Console.WriteLine(CenterText("| ➤ Phone Number      :                                                          |"));
            Console.WriteLine(CenterText("| ➤ Email             :                                                          |"));
            Console.WriteLine(CenterText("| ➤ date of birth     :                                                          |"));
            Console.WriteLine(CenterText("| ➤ Gender            :                                                          |"));
            Console.WriteLine(CenterText("| ➤ Write your hobbies:                                                          |"));
            Console.WriteLine(CenterText("+================================================================================+"));
            Console.ForegroundColor = ConsoleColor.White;
            string[] parts = line.Split(',');
            Console.SetCursorPosition(42, 3);
            Console.WriteLine(parts[0]); // Username
            Console.SetCursorPosition(42, 4);
            Console.WriteLine(parts[1]); // Password
            Console.SetCursorPosition(42, 5);
            Console.WriteLine(parts[2]); // Name
            Console.SetCursorPosition(42, 6);
            Console.WriteLine(parts[3]); // Phone Number
            Console.SetCursorPosition(42, 7);
            Console.WriteLine(parts[4]); // Email
            Console.SetCursorPosition(42, 8);
            Console.WriteLine(parts[5]); // Date of Birth
            Console.SetCursorPosition(42, 9);
            Console.WriteLine(parts[6]); // Gender
            Console.SetCursorPosition(42, 10);
            Console.WriteLine(parts[7]); // Hobbies
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(0, 12);
            Console.Write("press any key to return to the main menu...");
            Console.ReadKey();
            DisplayMenu(string.Join(",", parts));
        }
        static void Register()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            // عرض واجهة المستخدم لتسجيل حساب جديد
            Console.WriteLine(CenterText("+================================================================================+"));
            Console.WriteLine(CenterText("|                                 Register                                       |"));
            Console.WriteLine(CenterText("+================================================================================+"));
            Console.WriteLine(CenterText("| ➤ Username          :                                                          |"));
            Console.WriteLine(CenterText("| ➤ Password          :                                                          |"));
            Console.WriteLine(CenterText("| ➤ Name              :                                                          |"));
            Console.WriteLine(CenterText("| ➤ Phone Number      :                                                          |"));
            Console.WriteLine(CenterText("| ➤ Email             :                                                          |"));
            Console.WriteLine(CenterText("| ➤ date of birth     :                                                          |"));
            Console.WriteLine(CenterText("| ➤ Gender            :                                                          |"));
            Console.WriteLine(CenterText("| ➤ Write your hobbies:                                                          |"));
            Console.WriteLine(CenterText("+================================================================================+"));
            Console.WriteLine(CenterText("|          [ Please enter the required information above ]                       |"));
            Console.WriteLine(CenterText("|          [ Press ENTER after each input to continue ]                          |"));
            Console.WriteLine(CenterText("+================================================================================+"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(42, 3);
            string username = ValidateUsername(Console.ReadLine(), 42, 3, 0, 16);
            Console.SetCursorPosition(42, 4);
            string password = Console.ReadLine();
            Console.SetCursorPosition(42, 5);
            string name = ValiDateName(Console.ReadLine(), 42, 5, 0, 16);
            Console.SetCursorPosition(42, 6);
            string phoneNumber = ValiDatephoneNumber(Console.ReadLine(), 42, 6, 0, 16);
            Console.SetCursorPosition(42, 7);
            string email = ValidateEmailForDoctors(Console.ReadLine(), 42, 7, 0, 16);
            Console.SetCursorPosition(42, 8);
            string dateOfBirth = ValidateDateOfBirth(Console.ReadLine(), 42, 8, 0, 16);
            Console.SetCursorPosition(42, 9);
            string gender = ValidateGender(Console.ReadLine(), 42, 9, 0, 16);
            Console.SetCursorPosition(42, 10);
            string hobbies = ValidateHobbies(Console.ReadLine(), 42, 10, 0, 16);
            // كتابة البيانات المدخلة إلى ملف البيانات
            string lines = $"{username},{password},{name},{phoneNumber},{email},{dateOfBirth},{gender},{hobbies}";
            // التحقق من وجود الملف وإذا لم يكن موجودًا، إنشاءه
            if (!File.Exists(path))
            {
                File.WriteAllText(path, lines);
            }
            else
            {
                File.AppendAllText(path, Environment.NewLine + lines);
            }
            // عرض رسالة نجاح التسجيل
            Console.ForegroundColor = ConsoleColor.Green;
            WriteSlow("Registration successful! You can now log in.", 20, 0, 12);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Press any key to return to the login menu...");
            Console.ReadKey();
            DisplayLoginMenu();
        }
        //دالة ValidatePassword تقوم بالتحقق من صحة كلمة المرور المدخلة
        static string ValidatePassword(string password, int xaxis, int yaxis, int xaxis1, int yaxis1)
        {
            string title = "Invalid password, Please enter a valid password (8 to 18 characters), try again. ";
            while (true)
            {
                if (password.Length >= 8 && password.Length <= 18)
                {
                    space(title, xaxis1, yaxis1);
                    return password;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(xaxis1, yaxis1);
                    Console.Write(title);
                    space(password, xaxis, yaxis);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(xaxis, yaxis);
                    password = Console.ReadLine();
                }
            }
        }
        // دالة ValidateUsername تقوم بالتحقق من صحة اسم المستخدم المدخل
        static string ValidateUsername(string username, int xaxis, int yaxis, int xaxis1, int yaxis1)
        {
            string title = "Invalid username, Please enter a valid username (at least 5 characters), try again. ";
            
            while (true)
            {
                if (username.Length >= 5 && !username.Contains(" "))
                {
                    space(title, xaxis1, yaxis1);
                    string title1 = "Username already exists, Please enter a different username, try again. ";
                    if (File.Exists(path))
                    {
                        // تعريف كائن FileInfo للحصول على معلومات الملف
                        FileInfo fileInfo = new FileInfo(path);
                        // إذا كان الملف فارغًا يدخل المستخدم مباشرة
                        // fileInfo.Length == 0 يعني أن حجم الملف هو صفر بايت، أي أنه فارغ
                        if (fileInfo.Length == 0)
                        {
                            space(title1, xaxis1, yaxis1);
                            return username;
                        }
                        // قراءة جميع الأسطر من الملف والتحقق من وجود اسم المستخدم
                        string[] lines = File.ReadAllLines(path);
                        foreach (string line in lines)
                        {
                            string[] parts = line.Split(',');
                            // إذا كان اسم المستخدم موجودًا، يطلب من المستخدم إدخال اسم مستخدم آخر
                            if (parts[0] == username)
                            {
                                space(title1, xaxis1, yaxis1);
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.SetCursorPosition(xaxis1, yaxis1);
                                Console.Write(title1);
                                space(username, xaxis, yaxis);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(xaxis, yaxis);
                                username = Console.ReadLine();
                                break;
                            }
                            // إذا لم يكن اسم المستخدم موجودًا، يتم إرجاع اسم المستخدم
                            else
                            {
                                space(title1, xaxis1, yaxis1);
                                return username;
                            }
                        }
                    }
                    // إذا لم يكن الملف موجودًا، يتم إنشاء ملف جديد وإرجاع اسم المستخدم
                    else
                    {
                        space(title1, xaxis1, yaxis1);
                        return username;
                    }
                }
                // إذا كان اسم المستخدم غير صالح، يطلب من المستخدم إدخال اسم مستخدم آخر
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(xaxis1, yaxis1);
                    Console.Write(title);
                    space(username, xaxis, yaxis);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(xaxis, yaxis);
                    username = Console.ReadLine();
                }
            }
        }
        // دالة ValidateHobbies تقوم بالتحقق من صحة الهوايات المدخلة
        static string ValiDateName(string name, int xaxis, int yaxis, int xaxis1, int yaxis1)
        {
            string title = "invalid name, Please enter a valid name (at least 8 characters,first and last name must be more than 3 characters) ,try again. ";
            while (true)
            {
                // التحقق من طول الاسم ووجود مسافة بين الاسم الأول والاسم الأخير
                if (name.Length > 7 && name.Contains(' '))
                {
                    // تقسيم الاسم إلى أجزاء باستخدام المسافة كفاصل
                    string[] nameParts = name.Split(' ');
                    // التحقق من أن الاسم الأول والاسم الأخير يتكونان من أحرف فقط وطولهما أكبر من 3 أحرف
                    if (nameParts[0].Length > 3 && nameParts[0].All(char.IsLetter) && nameParts[1].Length > 3 && nameParts[1].All(char.IsLetter))
                    {
                        space(title, xaxis1, yaxis1);
                        return name;
                    }
                    // إذا لم يكن الاسم صالحًا، يطلب من المستخدم إدخال اسم آخر
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(xaxis1, yaxis1);
                        Console.Write(title);
                        space(name, xaxis, yaxis);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xaxis, yaxis);
                        name = Console.ReadLine();
                    }
                }
                // إذا لم يكن الاسم صالحًا، يطلب من المستخدم إدخال اسم آخر
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(xaxis1, yaxis1);
                    Console.Write(title);
                    space(name, xaxis, yaxis);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(xaxis, yaxis);
                    name = Console.ReadLine();
                }
            }
        }
        // دالة ValiDatephoneNumber تقوم بالتحقق من صحة رقم الهاتف المدخل
        static string ValiDatephoneNumber(string phoneNumber, int xaxis, int yaxis, int xaxis1, int yaxis1)
        {
            string title = "Invalid phone number, Please enter a valid phone number (11 digits, starts with 010, 011, 012, or 015), try again. ";
            while (true)
            {
                // التحقق من أن رقم الهاتف يتكون من 11 رقمًا ويبدأ بنفس بداية الشركات المصرية للاتصالات
                if (phoneNumber.Length == 11 && phoneNumber.All(char.IsDigit) && (phoneNumber.StartsWith("010") || phoneNumber.StartsWith("011") || phoneNumber.StartsWith("012") || phoneNumber.StartsWith("015")))
                {
                    space(title, xaxis1, yaxis1);
                    return phoneNumber;
                }
                // إذا لم يكن رقم الهاتف صالحًا، يطلب من المستخدم إدخال رقم آخر
                else
                {
                    space(title, xaxis1, yaxis1);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    WriteSlow(title, 20, xaxis1, yaxis1);
                    space(phoneNumber, xaxis, yaxis);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(xaxis, yaxis);
                    phoneNumber = Console.ReadLine();
                }
            }
        }
        // دالة ValidateEmailForDoctors تقوم بالتحقق من صحة البريد الإلكتروني المدخل
        static string ValidateEmailForDoctors(string email, int xaxis, int yaxis, int xaxis1, int yaxis1)
        {
            string title = "Invalid email, Please enter a valid email (must contain '@' and a valid domain), try again. ";
            // التحقق من صحة البريد الإلكتروني باستخدام مجموعة من النطاقات الشائعة
            while (true)
            {
                // التحقق من وجود '@' في البريد الإلكتروني وتفادي الاستثناءات
                try
                {
                    // تقسيم البريد الإلكتروني إلى أجزاء باستخدام '@' كفاصل
                    string[] parts = email.Split('@');
                    // التحقق من أن الجزء الأول من البريد الإلكتروني يحتوي على أكثر من 5 أحرف
                    if (parts[0].Length > 5)
                    {
                        // التحقق من أن الجزء الثاني من البريد الإلكتروني يحتوي على نطاق صالح
                        if (parts[1] == ("gmail.com") || parts[1] == ("@outlook.com") || parts[1] == ("@hotmial.com") || parts[1] == ("@gmail.com") || parts[1] == ("@live.com") || parts[1] == ("@yahoo.com") || parts[1] == ("@icloud.com"))
                        {
                            // إذا كان البريد الإلكتروني صالحًا
                            space(title, xaxis1, yaxis1);
                            return email;
                        }
                        // إذا لم يكن الجزء الثاني من البريد الإلكتروني يحتوي على نطاق صالح، يطلب من المستخدم إدخال بريد إلكتروني آخر
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.SetCursorPosition(xaxis1, yaxis1);
                            Console.Write(title);
                            space(email, xaxis, yaxis);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(xaxis, yaxis);
                            email = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(xaxis1, yaxis1);
                        Console.Write(title);
                        space(email, xaxis, yaxis);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xaxis, yaxis);
                        email = Console.ReadLine();
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(xaxis1, yaxis1);
                    Console.Write(title);
                    space(email, xaxis, yaxis);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(xaxis, yaxis);
                    email = Console.ReadLine();
                }
            }   
        }
        // دالة ValidateDateOfBirth تقوم بالتحقق من صحة تاريخ الميلاد المدخل
        static string ValidateDateOfBirth(string date, int xaxis, int yaxis, int xaxis1, int yaxis1)
        {
            string title = "Invalid date of birth, Please enter a valid date in the format dd/mm/yyyy, try again. ";
            while (true)
            {
                // التحقق من أن التاريخ المدخل يتبع التنسيق الصحيح
                DateTime parsedDate;
                // محاولة تحليل التاريخ المدخل إلى كائن DateTime
                if (DateTime.TryParse(date, out parsedDate))
                {
                    // التحقق من أن تاريخ الميلاد لا يكون في المستقبل
                    if (parsedDate <= DateTime.Now)
                    {
                        space(title, xaxis1, yaxis1);
                        return parsedDate.ToString("dd/MM/yyyy");
                    }
                    // إذا كان تاريخ الميلاد في المستقبل، يطلب من المستخدم إدخال تاريخ آخر
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(xaxis1, yaxis1);
                        Console.Write(title);
                        space(date, xaxis, yaxis);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xaxis, yaxis);
                        date = Console.ReadLine();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(xaxis1, yaxis1);
                    Console.Write(title);
                    space(date, xaxis, yaxis);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(xaxis, yaxis);
                    date = Console.ReadLine();
                }
            }
        }
        // دالة ValidateGender تقوم بالتحقق من صحة الجنس المدخل
        private static string ValidateGender(string gender, int xaxis, int yaxis, int xaxis1, int yaxis1)
        {
            string title = "invalid gnder, Please enter a valid gender (Male,female) ,try again. ";
            while (true)
            {
                // تقوم gender.Trim().ToLower() بتحويل الجنس إلى أحرف صغيرة وإزالة المسافات الزائدة للتأكد من تطابقه مع القيم المتوقعة
                gender = gender.Trim().ToLower();
                if (gender == "male" || gender == "female")
                {
                    space(title, xaxis1, yaxis1);
                    return gender.ToUpper();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(xaxis1, yaxis1);
                    Console.Write(title);
                    space(gender, xaxis, yaxis);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(xaxis, yaxis);
                    gender = Console.ReadLine();
                }
            }
        }
        // دالة ValidateHobbies تقوم بالتحقق من صحة الهوايات المدخلة
        static string ValidateHobbies(string hobbies, int xaxis, int yaxis, int xaxis1, int yaxis1)
        {
            string title = "Invalid hobbies, Please enter valid hobbies (3 to 58 characters) and no commas, try again. ";
            while (true)
            {
                // التحقق من أن الهوايات تتكون من 3 إلى 58 حرفًا ولا تحتوي على فاصلة
                if (hobbies.Length >= 3 && hobbies.Length<=58 && !hobbies.Contains(","))
                {
                    space(title, xaxis1, yaxis1);
                    return hobbies;
                }
                // إذا لم تكن الهوايات صالحة، يطلب من المستخدم إدخال هوايات أخرى
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(xaxis1, yaxis1);
                    Console.Write(title);
                    space(hobbies, xaxis, yaxis);
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.SetCursorPosition(100, yaxis);
                    Console.Write("|");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(xaxis, yaxis);
                    hobbies = Console.ReadLine();
                }
            }
        }
        //دالة ValidateInput تقوم بالتحقق من صحة الإدخال المدخل من قبل المستخدم
        static int ValidateInput(string input, int xaxis, int yaxis, int xaxis1, int yaxis1)
        {
            int value;
            string title = "Invalid input ,try again plese enter valid input";
            while (true)
            {
                // التحقق من أن الإدخال هو رقم صحيح
                if (!int.TryParse(input, out value))
                {
                    space(title, xaxis1, yaxis1);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    WriteSlow(title, 20, xaxis1, yaxis1);
                    space(input, xaxis, yaxis);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(xaxis, yaxis);
                    input = Console.ReadLine();
                }
                else
                {
                    space(title, xaxis1, yaxis1);
                    return value;
                }
            }
        }
        //دالة space تقوم بإزالة الكتابة في مكان معين في الشاشة
        static void space(string input, int xaise, int yaise)
        {
            //loop تلف حول طول الإدخال وتقوم بإزالة الكتابة في المكان المحدد
            for (int i = 0; i < input.Length; i++)
            {
                int positionX = xaise + i;
                // التحقق من أن الموضع لا يتجاوز حدود الشاشة
                // console.BufferWidth و Console.BufferHeight تعطيان عرض وارتفاع الشاشة
                if (positionX < Console.BufferWidth && yaise < Console.BufferHeight)
                {
                    Console.SetCursorPosition(positionX, yaise);
                    Console.Write(" ");
                }
            }
        }
        //دالة WriteSlow تقوم بكتابة النص ببطء على الشاشة
        static void WriteSlow(string word, int delay, int xaxis, int yaxis)
        {
            //loop تلف حول طول الكلمة وتقوم بكتابتها ببطء في المكان المحدد
            for (int i = 0; i < word.Length; i++)
            {
                // تعيين موضع الكتابة على الشاشة
                Console.SetCursorPosition(xaxis + i, yaxis);
                // كتابة الحرف الحالي من الكلمة
                Console.Write(word[i]);
                // الانتظار لمدة معينة قبل كتابة الحرف التالي
                Thread.Sleep(delay);
            }
        }
    }
}
