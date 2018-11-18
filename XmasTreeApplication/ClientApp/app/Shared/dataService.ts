import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Order} from "./Order";
import {Product} from "./Product";
import {Observable} from "rxjs";
import {map} from "rxjs/operators";

@Injectable
export class DataService {
    
    constructor(private http: HttpClient){
        
    }

    public order: Order = new Order();
    public products: Product[] = [];
    
    loadProducts(): Observable<boolean>{
        return this.http.get("/api/products")
            .pipe(
                map((data: any[]) =>{
                this.products = data;
                return true;
            }));
    }
    
}
