import { DebugElement } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { BrowserModule, By } from '@angular/platform-browser';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { RepoServiceMock } from 'src/app/mocks/repository.service.mock';
import { RepositoryService } from 'src/app/shared/repository.service';

import { ProductCreateComponent } from './product-create.component';

describe('ProductCreateComponent', () => {
  let component: ProductCreateComponent;
  let fixture: ComponentFixture<ProductCreateComponent>;
  let de: DebugElement;
  let el: HTMLElement;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductCreateComponent ],
      imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        MatDialogModule,
        RouterModule
      ],
      providers:[
        { provide: RepositoryService, useClass: RepoServiceMock},
        { provide: Router, useValue:{} },
        { provide: ActivatedRoute, useValue:{ snapshot: { params: { 'id': '1'}} } }
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    
    de = fixture.debugElement.query(By.css('form'));
    el = de.nativeElement;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call the onsubmit method', () => {
    fixture.detectChanges();
    spyOn(component, 'onSubmit');
    el = fixture.debugElement.query(By.css('button')).nativeElement;
    el.click();
    expect(component.onSubmit).toHaveBeenCalledTimes(0);
  });

  it('form should be invalid', () => {
    component.productForm.controls['name'].setValue('');
    component.productForm.controls['company'].setValue('');
    component.productForm.controls['price'].setValue('');
    component.productForm.controls['maximunAge'].setValue('');
    component.productForm.controls['description'].setValue('');
    expect(component.productForm.valid).toBeFalsy();
  });

  it('form should be valid', () => {
    component.productForm.controls['name'].setValue('Test1023');
    component.productForm.controls['company'].setValue('Company');
    component.productForm.controls['price'].setValue('22.56');
    expect(component.productForm.valid).toBeTruthy();
  });

});
