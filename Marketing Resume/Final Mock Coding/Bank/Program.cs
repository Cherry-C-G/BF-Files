//Practice 5: C#
//Develop a program to generate banking transaction
//Instructions:
//Create a Customer Model class (CustomerId, CustomerName, Address, AccountBalance)
//Create Bank truncation class
//Initialize the Customer Object
//Set the Initial balance
//Develop a method in Bank class to Deposit amount to the customer
//Develop a method in bank class to Withdraw amount from the customer
//Develop a method to get the customer balance
//Develop a method to check whether customer has enough balance or not
//Develop a method to return customer info. Input:
//Customer(123, “Satya”, “Cranston, RI”, $500)
//Deposit(500) – Balance becomes $1000
//Withdraw (100) – Balance becomes $900
//Withdraw(5000) – throw error insufficient balance
//GetCustomerInfo() – 123, “Satya”, “Cransonton, RI”, { Balance}
//Note:
//Use properties, constructor, Exception Handling and List

using System;

public class Customer
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string Address { get; set; }
    public decimal AccountBalance { get; set; }
}

public class Bank
{
    private Customer customer;

    public Bank(Customer customer)
    {
        this.customer = customer;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be greater than zero.");
        }

        this.customer.AccountBalance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be greater than zero.");
        }

        if (amount > this.customer.AccountBalance)
        {
            throw new ArgumentException("Insufficient balance.");
        }

        this.customer.AccountBalance -= amount;
    }

    public decimal GetBalance()
    {
        return this.customer.AccountBalance;
    }

    public bool HasSufficientBalance(decimal amount)
    {
        return amount <= this.customer.AccountBalance;
    }

    public string GetCustomerInfo()
    {
        return $"{this.customer.CustomerId}, {this.customer.CustomerName}, {this.customer.Address}, {this.customer.AccountBalance:C}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Customer customer = new Customer()
        {
            CustomerId = 123,
            CustomerName = "Satya",
            Address = "Cranston, RI",
            AccountBalance = 500m
        };

        Bank bank = new Bank(customer);

        Console.WriteLine($"Initial customer info: {bank.GetCustomerInfo()}");

        try
        {
            bank.Deposit(500m);
            Console.WriteLine($"After deposit: {bank.GetCustomerInfo()}");

            bank.Withdraw(100m);
            Console.WriteLine($"After withdrawal: {bank.GetCustomerInfo()}");

            bank.Withdraw(5000m);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.ReadKey();
    }
}
