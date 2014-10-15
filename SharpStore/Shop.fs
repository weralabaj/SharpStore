namespace Shop

module CommonLibrary =
    type String50 = String50 of string
    let createString50 (s: string) =
        if s.Length < 50 
        then Some (String50 s)
        else None
    
    type String1 = String1 of string
    let createString1 (s: string) =
        if s.Length < 1
        then Some (String1 s)
        else None

    type Currency = NZD | AUD
    type Money = { Amount: decimal; Currency: Currency }


module Shop =
    open CommonLibrary

    type PersonalName = { FirstName: String50; MiddleInitial: String1 option; LastName: String50 }
    type CompanyName = { Name: string }
    type CustomerName = PersonalName | CompanyName
    
    type Email = string
    type PhoneNumber = string
    type Postcode = string
    type Address = { FirstLine: String50; SecondLine: String50 option; Postcode: String50; City: String50 }
    type ShippingInfo = { Customer: CustomerName; Address: Address; DeliveryInstructions: string}
    
    type ContactInfo = Email | Phone
    
    [<CustomEquality;NoComparison>]
    type Customer = {Id:int; Name:CustomerName; ContactInfo: ContactInfo} with
        override this.GetHashCode() = hash this.Id
        override this.Equals(other) =
            match other with
                | :? Customer as c -> this.Id = c.Id
                | _ -> false

    type ProductAttribute = { Name: String50; Value: String50 }
    type ProductDefinition = { Id: int; SKU:int; Attributes: ProductAttribute list }
    type VirtualProduct = { ProductInfo: ProductDefinition; DeliveryInfo: Email }
    type ShippableProduct = { ProductInfo: ProductDefinition; DeliveryInfo: ShippingInfo }
    type Product = VirtualProduct | ShippableProduct

    type OrderLine = { ItemId: int; Quantity: int; UnitPrice: Money; Total: Money}
    type Order = { Id:int; TrackingId: int; Lines: OrderLine list }
