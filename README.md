# Generic Cinema Management & JSON Persistence (C#)

This C# .NET 8.0 application represents the advanced stage of software development, focusing on **Generics** and **JSON Serialization**. It provides a flexible, type-safe architecture for managing data while ensuring that all records are preserved in a modern, standard data format.

###  Logic & Advanced Architecture
The system transitions from hard-coded structures to a more abstract and reusable design:
* **Generic Programming:** Utilizes `List<T>` and generic method constraints to create a system that can handle different data types without code duplication.
* **JSON Serialization:** Implements `System.Text.Json` to convert in-memory objects into a portable JSON format. This is the industry standard for web APIs and modern data storage.


###  Key Features
* **Type-Safe Data Engine:** Uses Generics to ensure that the cinema engine can process any viewer or session type with strict compile-time checking.
* **Standardized Persistence:** Replaces custom text parsing with **JSON storage** in `viewers.json`, making the data compatible with other modern applications.
* **Deep LINQ Integration:** Performs complex data transformations, including grouping and sorting, to generate loyalty rankings and session reports.
* **Asynchronous-Ready Design:** Structured in a way that allows for easy transition to async file operations in the future.


###  Technical Stack
* **Language:** C# (.NET 8.0)
* **Data Format:** JSON (JavaScript Object Notation).
* **Libraries:** `System.Text.Json`, `System.Linq`, `System.Collections.Generic`.
* **Concepts:** Generics, Serialization, Modern File I/O.

###  How to Use
1. Run the application to see the automated JSON data loading.
2. The system will manage `viewers.json` automatically, ensuring your cinema records are always up-to-date.
3. Use the menu to:
   - Browse the cinema schedule.
   - Buy tickets (data is instantly prepared for JSON serialization).
   - Generate loyalty reports using LINQ queries.
