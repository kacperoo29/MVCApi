import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryDto, CategoryService } from 'src/api';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {
  rootCategories: Observable<CategoryDto[]> = this.categoryService.apiCategoryGetRootCategoriesGet()

  constructor(private readonly categoryService: CategoryService) { }

  ngOnInit(): void {
  }

}
