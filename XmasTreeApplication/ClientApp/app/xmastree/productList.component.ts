import {Component, OnInit} from "@angular/core";
import {Product} from "../Shared/Product";
import {DataService} from "../Shared/dataService";

@Component({
    selector: "product-list",
    templateUrl: "productList.component.html",
    styleUrls: []
})

export class ProductList implements OnInit{
    public products: Product[]
    
    constructor(private data: DataService){
        
    }
    
    ngOnInit(){
        this.data.loadProducts()
            .subscribe(success => {
                if(success){
                    this.products = this.data.products;
                }
            });
    }
}