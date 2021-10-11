import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RepositoryService } from 'src/app/shared/repository.service';
import { Product } from '../_interface/product.model';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  public product: Product | undefined;
  
  constructor(private repository: RepositoryService, private router: Router, private activeRoute: ActivatedRoute) { }

  ngOnInit() {
    this.getProductDetail();
  }

  private getProductDetail = () =>{
    let id: string = this.activeRoute.snapshot.params['id'];
    let apiUrl: string = `api/product/${id}`;

    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.product = res as Product;
    },
    (error) =>{
      console.log(error);
    })
  }

}
