import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { RepositoryService } from 'src/app/shared/repository.service';
import { Product, ProductForCreation, ProductForUpdate } from '../_interface/product.model';
import { MatDialog } from '@angular/material/dialog';
import { SuccessDialogComponent } from 'src/app/shared/dialogs/success-dialog/success-dialog.component';
import { ErrorDialogComponent } from 'src/app/shared/dialogs/error-dialog/error-dialog.component';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.scss']
})
export class ProductCreateComponent implements OnInit {
  
  public productForm!: FormGroup;
  private dialogConfig!: any;
  public id!: number;
  public isAddMode!: boolean;
  public btnSendText!: string;

  constructor(private location: Location, private repository: RepositoryService, private dialog: MatDialog, private router: Router, private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.id = this.activeRoute.snapshot.params['id'];
    this.isAddMode = !this.id;

    this.productForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      price: new FormControl('', [Validators.required, Validators.pattern(/^\d+\.\d{2}$/), Validators.min(1), Validators.max(1000)]),
      company: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      maximunAge: new FormControl('', [Validators.min(0), Validators.max(100)]),
      description: new FormControl('', [Validators.maxLength(100)])
    });

    this.dialogConfig = {
      height: '200px',
      width: '400px',
      disableClose: true,
      data: { }
    }

    if (!this.isAddMode) {
      this.btnSendText = "Update";
      let apiUrl = 'api/product/'+this.id;
      this.repository.getData(apiUrl)
          .subscribe(
            x => this.productForm.patchValue(x)
          );
    }

    if(this.isAddMode){
      this.btnSendText = "Create";
    }

  }

  public hasError = (controlName: string, errorName: string) =>{
    return this.productForm.controls[controlName].hasError(errorName);
  }

  public onCancel = () => {
    this.location.back();
  }

  public onSubmit = (productFormValue: any) => {
    if (this.productForm.valid) {
      if(this.isAddMode){
        this.createProduct(productFormValue);
      }else {
        this.updateProduct(productFormValue);
      }
    }
  }

  private createProduct = (productFormValue: any) => {
    let product: ProductForCreation = {
      name: productFormValue.name,
      description: productFormValue.description,
      price: productFormValue.price,
      company: productFormValue.company,
      ageRestriccion: productFormValue.maximunAge == '' ? null : productFormValue.maximunAge 
    };
    let apiUrl = 'api/product';
    this.repository.create(apiUrl, product)
      .subscribe(res => {
        let dialogRef = this.dialog.open(SuccessDialogComponent, this.dialogConfig);
        dialogRef.afterClosed().subscribe(result => {
          this.location.back();
        });
      },
      (error => {
        console.log(error);
        this.dialogConfig.data = { 'errorMessage': error }
        this.dialog.open(ErrorDialogComponent, this.dialogConfig);
      })
    )
  }

  private updateProduct = (productFormValue: any) => {
    let product: Product = {
      id: this.id,
      name: productFormValue.name,
      description: productFormValue.description,
      price: productFormValue.price,
      company: productFormValue.company,
      ageRestriccion: productFormValue.maximunAge == '' ? null : productFormValue.maximunAge 
    };
    
    let apiUrl = 'api/product/'+this.id;
    this.repository.update(apiUrl, product)
      .subscribe(res => {
        let dialogRef = this.dialog.open(SuccessDialogComponent, this.dialogConfig);
        dialogRef.afterClosed().subscribe(result => {
          this.location.back();
        });
      },
      (error => {
        console.log(error);
        this.dialogConfig.data = { 'errorMessage': error.message }
        this.dialog.open(ErrorDialogComponent, this.dialogConfig);
      })
    )
  }


}
