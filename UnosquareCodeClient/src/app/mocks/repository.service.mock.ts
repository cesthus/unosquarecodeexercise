import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Product } from "../product/_interface/product.model";

@Injectable()
export class RepoServiceMock {
    constructor() {}

    public getData(): Observable<Product> {
        return Observable.create(this.getDummyData);
    }

    private getDummyData(): Product {
        let data: Product = {
            id: 1,
            name: "Roma test",
            description: "",
            ageRestriccion: 87,
            company: "Maaa",
            price: 45.44
        };

        return data;
    }
}