|  Classes |  Methods/Properties  |          Scenario         |      Outputs      |
|:--------:|:--------------------:|:-------------------------:|:-----------------:|
| Customer | AddBagel             | Space in basket           | Success           |
| Customer | AddBagel             | Full Basket               | Receive error     |
| Customer | AddBagel             | Bagel with custom filling | Success           |
| Customer | RemoveBagel          | Remove bagel from basket  | Success           |
| Customer | RemoveBagel          | Has no bagel to remove    | Receive Error     |
| Customer | GetBagelPrice        | Get price of bagel        | Int               |
| Customer | GetFillingPrices     | Get price of each filling | Dict<string, int> |
| Manager  | ChangeBasketCapacity | Adjust basket capacity    | Success           |
