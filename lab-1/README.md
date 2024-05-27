# Programming Principles in This Code
This code demonstrates adherence to several fundamental programming principles. Below is a detailed description of each principle, with links to the relevant files and lines of code.
## 1. DRY (Don't Repeat Yourself)
The DRY principle aims to reduce the repetition of code by ensuring that each piece of knowledge or logic is represented in a single place.
* **Implementation**: The [FormHeader](./Models/HtmlReport.cs#L91), [FormProductLine](./Models/HtmlReport.cs#L133), [FormTableHeader](./Models/HtmlReport.cs#L109), and [FormProductTables](./Models/HtmlReport.cs#L123) methods in the [HtmlReport](./Models/HtmlReport.cs) class are examples of shared methods used to avoid code duplication when creating different types of reports.
## 2. KISS (Keep It Simple, Stupid)
The KISS principle emphasizes simplicity in code design to make it more understandable and maintainable.
* **Implementation**: The [Logger](./Services/Logger.cs) class provides straightforward methods ([Info](./Services/Logger.cs#L13), [Warning](./Services/Logger.cs#L18), [Error](./Services/Logger.cs#L8)) for logging messages, keeping the logging functionality simple and easy to use.
## 3. SOLID Principles
### a. Single Responsibility Principle
Each class should have only one reason to change, meaning that a class should only have one job or responsibility.
* **Implementation**: The [WarehouseManager](./Managers/WarehouseManager.cs) class handles all warehouse-related operations, while the [ReportingService](./Services/ReportingService.cs) class manages report creation and deletion.
### b. Open/Closed Principle
Classes should be open for extension but closed for modification.
* **Implementation**: The [Money](./Models/Money.cs) class is abstract and can be extended to create different types of currency without modifying the existing code. The [Dollar](./Models/Dollar.cs) and [Euro](./Models/Euro.cs) classes extend Money.
### c. Liskov Substitution Principle
Objects of a superclass should be replaceable with objects of a subclass without affecting the functionality of the program.
* **Implementation**: The [HtmlReport](./Models/HtmlReport.cs) and [TextReport](./Models/TextReport.cs) classes implement the IReport interface, ensuring they can be used interchangeably wherever [IReport](./Interfaces/IReport.cs) is expected.
### d. Interface Segregation Principle
Clients should not be forced to depend on interfaces they do not use.
* **Implementation**: The [ILogger](./Interfaces/ILogger.cs), [IReport](./Interfaces/IReport.cs), [IReportingService](./Interfaces/IReportingService.cs), and [IWarehouseManager](./Interfaces/IWarehouseManager.cs) interfaces are designed to provide specific sets of methods related to their functionality, preventing clients from being forced to implement methods they do not need.
### e. Dependency Inversion Principle
High-level modules should not depend on low-level modules. Both should depend on abstractions.
* **Implementation**: The [WarehouseManager](./Managers/WarehouseManager.cs) and [ReportingService](./Services/ReportingService.cs) classes depend on the [ILogger](./Interfaces/ILogger.cs) interface rather than a specific logging implementation. This allows for different logging implementations to be used without changing the WarehouseManager or ReportingService code.
## 4. YAGNI (You Aren't Gonna Need It)
YAGNI emphasizes that functionality should not be added until it is necessary.
* **Implementation**: The code focuses on the necessary functionalities for managing products and generating reports. It avoids adding unnecessary features, keeping the codebase lean and focused.
* No superfluous features added.
## 5. Composition Over Inheritance
Favor composition over inheritance to achieve code reuse.
* **Implementation**: The [WarehouseManager](./Managers/WarehouseManager.cs) class uses composition by including a [Warehouse](./Managers/WarehouseManager.cs#L8) object and an [ILogger](./Managers/WarehouseManager.cs#L9) object to perform its operations, rather than inheriting from a base class.
## 6. Program to Interfaces, Not Implementations
Program to an interface so that the code can work with any class that implements the interface.
* **Implementation**: The use of interfaces like [ILogger](./Interfaces/ILogger.cs), [IReport](./Interfaces/IReport.cs), [IReportingService](./Interfaces/IReportingService.cs), and [IWarehouseManager](./Interfaces/IWarehouseManager.cs) ensures that the code can work with any class that implements these interfaces.
## 7. Fail Fast
The fail-fast principle suggests that a system should report any failure immediately.
* **Implementation**: The [SetMoney](./Models/Money.cs#L10-19) method in the [Money](./Models/Money.cs) class checks for invalid values and throws an [ArgumentOutOfRangeException](./Models/Money.cs#L13) if the values are not within the expected range.
