import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { RepositoryService } from 'src/app/shared/repository.service';
import { Product } from '../_interface/product.model';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit, AfterViewInit {

  public displayedColumns = ['id', 'name', 'age', 'price', 'company', 'details', 'update', 'delete'];
  public dataSource = new MatTableDataSource<Product>();

  @ViewChild(MatSort) sort: MatSort = new MatSort;
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  constructor(private repoService: RepositoryService, private router: Router) { }

  ngOnInit(): void {
    this.getAllProducts();
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  public getAllProducts = () => {
    this.repoService.getData('api/product')
    .subscribe(res => {
      this.dataSource.data = res as Product[];
    })
  }

  public doFilter = (target: any) => {
    this.dataSource.filter = target.value.trim().toLocaleLowerCase();
  }

  public redirectToDetails = (id: string) => {
    let url: string = `/product/details/${id}`;
    this.router.navigate([url]);
  }
  public redirectToUpdate = (id: string) => {
    let url: string = `/product/edit/${id}`;
    this.router.navigate([url]);
  }
  public redirectToDelete = (id: string) => {
    
  }

}
