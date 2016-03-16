using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class CustomerTypeRepository
    {
        public List<CustomerType> Retrieve()
        {
            List<CustomerType> customerTypes = new List<CustomerType>
                    { 
                new CustomerType(){
                    CustomerTypeId = 1,
                    TypeName="Corporate",
                    DispalyOrder=2 
                },
                new CustomerType(){
                    CustomerTypeId = 2,
                    TypeName="Individual",
                    DispalyOrder=1
                },
                new CustomerType(){
                    CustomerTypeId = 3,
                    TypeName="Educator",
                    DispalyOrder=4
                },
                new CustomerType(){
                    CustomerTypeId = 4,
                    TypeName="Goverment",
                    DispalyOrder=3
                }};
            return customerTypes;
        }
               
    }
}
