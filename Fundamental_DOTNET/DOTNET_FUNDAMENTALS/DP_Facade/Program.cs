using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Facade
{
    /*
     *  Definition(from Gof book):- “Facade provides a unified interface to a set of interfaces in a subsystem”.

        So it is clear if the software system is composed of number of subsystems (which generally is the case) we may want to create a “facade” object which would call all these subsystems from one place. The main adavantages of incorporating a facade pattern are:
        1) It provides a single simplified interface and hence makes the subsystems easier to use.
        2) The client code is shielded from creating various objects of subsystem. This would be taken care of facade object.
        3) Facade object decouples the subsystem from the client and other subsystems.
     
     *  The online shopping store has to process a series of complicated steps before it ships your favorite product at your address. 
        These steps can be updating their inventory, verifying your shipping address for delivery, verifying your credit card details, 
        applying various discounts and what not. 
        Since all these steps are complicated so suppose each step forms a subsystem of the larger system (online ordering). 
        When the online store performs these operations it may want to call a single operation say “FinalizeOrder” which would 
        in turn call all these subsytems. We can sense this may be the perfect place where we can apply facade pattern. 
        So we will create a facade object which would call the sybsystems which are: 
            InventoryUpdate, 
            AddressVerification, 
            Discounting, 
            PayCardVerification, 
            Shipping.
     */
    //SubSystem - InventoryUpdate
    interface IInventory
    {
        void Update(int productId);
    }

    class InventoryManager : IInventory
    {
        public void Update(int productId)
        {
            Console.WriteLine(string.Format("Product# {0} is subtracted from the store's inventory.", productId));
        }
    }
    //SubSystem - AddressVerification
    interface IOrderVerify
    {
        bool VerifyShippingAddress(int pincode);
    }

    class OrderVerificationManager : IOrderVerify
    {

        public bool VerifyShippingAddress(int pincode)
        {
            Console.WriteLine(string.Format("The product can be shipped to the pincode {0}.", pincode));
            return true;
        }
    }
    //SubSystem - Discounts and costing
    interface ICosting
    {
        float ApplyDiscounts(float price, float discountPercent);
    }


    class CostManager : ICosting
    {

        public float ApplyDiscounts(float price, float discountPercent)
        {
            Console.WriteLine(string.Format("A discount of {0}% has been applied on the product's price of {1}", discountPercent, price));
            return price - ((discountPercent / 100) * price);
        }
    }

    //SubSystem - PayCardVerification
    interface IPaymentGateway
    {
        bool VerifyCardDetails(string cardNo);
        bool ProcessPayment(string cardNo, float cost);
    }


    class PaymentGatewayManager : IPaymentGateway
    {
        public bool VerifyCardDetails(string cardNo)
        {
            Console.WriteLine(string.Format("Card# {0} has been verified and is accepted.", cardNo));
            return true;
        }

        public bool ProcessPayment(string cardNo, float cost)
        {
            Console.WriteLine(string.Format("Card# {0} is used to make a payment of {1}.", cardNo, cost));
            return true;
        }
    }

    //SubSystem - Shipping
    interface ILogistics
    {
        void ShipProduct(string productName, string shippingAddress);
    }

    class LogisticsManager : ILogistics
    {
        public void ShipProduct(string productName, string shippingAddress)
        {
            Console.WriteLine(string.Format("Congratulations your product {0} has been shipped at the following address: {1}",
                                            productName,
                                            shippingAddress));
        }
    }

    class OrderDetails
    {
        public int ProductNo { get; private set; }

        public string ProductName { get; private set; }
        public string ProductDescription { get; private set; }
        public float Price { get; set; }
        public float DiscountPercent { get; private set; }
        public string AddressLine1 { get; private set; }
        public string AddressLine2 { get; private set; }
        public int PinCode { get; private set; }
        public string CardNo { get; private set; }

        public OrderDetails(string productName, string prodDescription, float price,
                            float discount, string addressLine1, string addressLine2,
                            int pinCode, string cardNo)
        {
            this.ProductNo = new Random(1).Next(1, 100);
            this.ProductName = productName;
            this.ProductDescription = prodDescription;
            this.Price = price;
            this.DiscountPercent = discount;
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.PinCode = pinCode;
            this.CardNo = cardNo;
        }
    }

    class OnlineShoppingFacade
    {
        IInventory inventory = new InventoryManager();
        IOrderVerify orderVerify = new OrderVerificationManager();
        ICosting costManger = new CostManager();
        IPaymentGateway paymentGateWay = new PaymentGatewayManager();
        ILogistics logistics = new LogisticsManager();

        public void FinalizeOrder(OrderDetails orderDetails)
        {
            inventory.Update(orderDetails.ProductNo);
            orderVerify.VerifyShippingAddress(orderDetails.PinCode);
            orderDetails.Price = costManger.ApplyDiscounts(orderDetails.Price,
                                                           orderDetails.DiscountPercent);
            paymentGateWay.VerifyCardDetails(orderDetails.CardNo);
            paymentGateWay.ProcessPayment(orderDetails.CardNo, orderDetails.Price);
            logistics.ShipProduct(orderDetails.ProductName, string.Format("{0}, {1} - {2}.",
                                  orderDetails.AddressLine1, orderDetails.AddressLine2,
                                  orderDetails.PinCode));
        }
    }

    class Program
    {
        /* static void Main(string[] args)
        {
            // Creating the Order/Product details
            OrderDetails orderDetails = new OrderDetails("C# Design Pattern Book",
                                                         "Simplified book on design patterns in C#",
                                                          500,
                                                          10,
                                                          "Street No 1",
                                                          "Educational Area",
                                                          1212,
                                                          "4156213754"
                                                         );

            //Client Code without Facade.

            // Updating the inventory.
            IInventory inventory = new InventoryManager();
            inventory.Update(orderDetails.ProductNo);

            // Verfying various details for the order such as the shipping address.
            IOrderVerify orderVerify = new OrderVerificationManager();
            orderVerify.VerifyShippingAddress(orderDetails.PinCode);



            // Calculating the final cost after applying various discounts.
            ICosting costManger = new CostManager();
            orderDetails.Price = costManger.ApplyDiscounts(orderDetails.Price,
                                                         orderDetails.DiscountPercent
                                                        );

            // Going through various steps if payment gateway like card verification, charging from the card.
            IPaymentGateway paymentGateWay = new PaymentGatewayManager();
            paymentGateWay.VerifyCardDetails(orderDetails.CardNo);
            paymentGateWay.ProcessPayment(orderDetails.CardNo, orderDetails.Price);

            // Completing the order by providing Logistics.
            ILogistics logistics = new LogisticsManager();
            logistics.ShipProduct(orderDetails.ProductName, string.Format("{0}, {1} - {2}.",
                                  orderDetails.AddressLine1, orderDetails.AddressLine2,
                                  orderDetails.PinCode));
        } */

        static void Main(string[] args)
        {
            // Creating the Order/Product details
            OrderDetails orderDetails = new OrderDetails("C# Design Pattern Book",
                                                         "Simplified book on design patterns in C#",
                                                         500,
                                                         10,
                                                         "Street No 1",
                                                         "Educational Area",
                                                         1212,
                                                         "4156213754"
                                                         );

            // Using Facade
            OnlineShoppingFacade facade = new OnlineShoppingFacade();
            facade.FinalizeOrder(orderDetails);

            Console.ReadLine();

        }
    }
}
