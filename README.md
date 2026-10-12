# 🍕 Pizza Order Management System (PizzaProject)

A desktop Windows Forms application built in C# and .NET for customizing pizzas, browsing menus, and calculating real-time order prices.

---

## ✨ Features

- **Custom Pizza Builder**:
  - **Sizes**: Small, Medium, Large
  - **Crust Types**: Thin Crust, Thick Crust
  - **Toppings**: Mozzarella Cheese, Mushrooms, Olives, Tomatoes, Onions, Green Peppers
- **Real-Time Price Calculation**: Instant recalculation based on selected toppings, crust, and sizes.
- **Menu Browser**: Explore pizzas and special items.
- **Order Summary & Confirmation**: Clean order review before final placement.
- **Intuitive GUI**: Easy-to-use desktop user interface powered by Windows Forms.

---

## 🛠️ Tech Stack

- **Language**: C# (.NET Framework 4.7.2)
- **Framework**: Windows Forms (WinForms)
- **IDE**: Visual Studio 2022 / 2019

---

## 📂 Project Structure

```text
PizzaProject/
├── PizzaProject.slnx          # Visual Studio Solution
├── PizzaProject/
│   ├── FrmMain.cs             # Welcome & Entry screen
│   ├── FrmTableOfMenu.cs      # Menu display form
│   ├── FrmBuildPizza.cs       # Custom pizza builder & topping selector
│   ├── FrmOrder.cs            # Order details & summary
│   ├── clsPrices.cs           # Pricing model & constants
│   ├── PizzaOrder.cs          # Order state and customer selection
│   ├── PizzaProject.csproj    # C# Project definition
│   └── Properties/            # Resources & application settings
├── .gitignore                 # Visual Studio ignore rules
└── README.md                  # Project documentation
```

---

## 🚀 Getting Started

### Prerequisites
- Windows 10 / 11
- [.NET Framework 4.7.2 Runtime or Developer Pack](https://dotnet.microsoft.com/download/dotnet-framework/net472)
- [Visual Studio](https://visualstudio.microsoft.com/) with the **.NET desktop development** workload installed

### How to Run

1. Clone the repository:
   ```bash
   git clone git@github.com:Salah6-9/PizzaProject.git
   ```
2. Open `PizzaProject.slnx` or `PizzaProject.csproj` in Visual Studio.
3. Build the solution (`Ctrl + Shift + B`).
4. Press **F5** (or click **Start**) to launch the application.

---

## 📄 License
This project is open-source under the [MIT License](LICENSE).
