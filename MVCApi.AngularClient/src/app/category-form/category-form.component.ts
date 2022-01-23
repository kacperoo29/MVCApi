import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { CategoryDto, CategoryService, CreateCategory, CreateSubcategory } from 'src/api';

@Component({
  selector: 'app-category-form',
  templateUrl: './category-form.component.html',
  styleUrls: ['./category-form.component.css']
})
export class CategoryFormComponent implements OnInit {
  form = new FormGroup({
    name: new FormControl('', Validators.required),
    parent: new FormControl(''),
    isChild: new FormControl(false),
  });
  submitted : boolean = false;
  isSubCategory : boolean = false;
  parent : any = null;
  checked : boolean = false;

  constructor( 
    private readonly categoryService: CategoryService,
    private router: Router
    ) { }

  categories: Observable<CategoryDto[]> = this.categoryService.apiCategoryGetAllCategoriesGet()

  ngOnInit(): void {
  }

  get f(): { [key: string]: AbstractControl; }
  {
    return this.form.controls;
  }

  toggleEditable(event: { target: { checked: any; }; }) {
    if ( event.target.checked ) {
      this.isSubCategory = true;
    }
    else {
      this.isSubCategory = false;
    }
    console.log(this.isSubCategory);
  }


  submit():void{
    if (this.form.valid) {
      //If is not a child
      var createCategory: CreateCategory = this.form.value;
      if(this.form.get('isChild')?.value===false){
        this.categoryService
        .apiCategoryCreateCategoryPost(createCategory)
        .subscribe({
          next: () => {
            this.router.navigate(['/', 'categories']);
            console.log('Added')
          },
          error: (err) => console.log(err),
        });
      }
      //If is a child
      else{
        var createSubcategory: CreateSubcategory = {name: this.form.get('name')?.value.toString(), parentId: this.form.get('parent')?.value.toString()}

        this.categoryService
        .apiCategoryCreateSubcategoryPost(createSubcategory)
        .subscribe({
          next: () => {
            this.router.navigate(['/', 'categories']);
            console.log('Added sub')
          },
          error: (err) => console.log(err),
        });
      }
      
    }
  }
}
