# CRUD_Navigation 🧭

**CRUD_Navigation** is a lightweight WPF application designed to demonstrate efficient data management and **View-based navigation** within the .NET ecosystem. It provides a seamless user experience by swapping views dynamically within a single main window.

## 🚀 Key Features

* **View Management:** Browse and display stored records in a structured data grid or list.
* **Create (Add):** Dedicated navigation view for inputting new data entries.
* **Update (Modify):** Edit existing records with pre-populated fields via selection-based navigation.
* **Delete:** Remove records directly from the management interface.
* **Dynamic Navigation:** Uses a ContentControl-based navigation system to switch between "Home," "Add," and "Edit" views without opening multiple windows.

## 🛠️ Technical Specifications

* **Framework:** Built with **WPF (.NET)** for a native Windows experience.
* **Architecture:** Follows the **MVVM (Model-View-ViewModel)** design pattern for clean separation of UI and logic.
* **Database:** Powered by **SQLite** for portable, configuration-free local storage.
* **Navigation:** Implements a `ViewModel-First` navigation approach using DataTemplates.

## 📂 Project Structure

* **`Views/`**: XAML UserControls for each screen (e.g., `ListView.xaml`, `EditorView.xaml`).
* **`ViewModels/`**: Logic handling navigation commands and CRUD operations.
* **`Models/`**: Data definitions and entity structures.
* **`Services/`**: Database context and navigation state management.

## 🔧 Setup & Build

1. **Prerequisites:** Visual Studio with the **.NET Desktop Development** workload.
2. **Clone the Repo:**
   ```bash
   git clone [https://github.com/zakariabouchelaghm/CRUD_Navigation](https://github.com/zakariabouchelaghm/CRUD_Navigation)
