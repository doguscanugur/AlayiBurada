# AlayiBurada

This project was prepared by [Burak Akyüz](https://www.linkedin.com/in/burakyuzz/) and [Doğuş Can Uğur](https://www.linkedin.com/in/doguscanugur/) in November 2021 as a graduation project of **"[KODLUYORUZ](https://kodluyoruz.org/) Ankara C# with .NET Core Bootcamp"**.

**AlayiBurada E-Commerce** is developed using enterprise architecture with *ASP.NET MVC*. These layers are BusinessLayer, DataAccessLayer, Entities, Interfaces, UserInterface.
EntityFramework, PagedList, jQueryAjax, ELMAH libraries are used in this project. But it can be used in MicroORM.

**JQuery Ajax** is used in cart operations.
Unhandled Errors encountered during RunTime are recorded in the database with the help of **ELMAH.**
**PagedList** is used for paging operations.
*CodeFirst* approach is used with **EntityFramework** for DataAccessLayer.
*SHA512* is used for password hashing operations.
It is not very powerful on the FrontEnd side because the main purpose of the course is on BackEnd.



## USE SCENARIO

After logging in, the user can actively add, delete, and clean his cart. You can make purchases in your cart. Card transactions are not added. It can bring and list products by category. You can actively see your cart.
After logging in to the Admin, they can have complete control of the site by performing the necessary CRUD operations related to the Product, Customer, Category.

![PublicUI](https://raw.githubusercontent.com/burakyuz1/AlayiBurada/master/Alay%C4%B1Burada.MvcUI/img/img-1.gif)


