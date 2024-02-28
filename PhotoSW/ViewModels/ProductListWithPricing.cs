using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.IMIX.Model;
namespace PhotoSW.ViewModels
{
   public class ProductListWithPricing
    {
   
  public bool? IsAvailable  {get;set;}
  public List<CurrencyInfo> LstCurrency { get; set; }
  public double? Price  {get;set;}
  public string ProductType {get;set;}
  public int? ProductTypeId { get; set; }
  public string SelectedCurrency { get; set; }
   
   
   
   
   
   
   
   
   
   }
}
