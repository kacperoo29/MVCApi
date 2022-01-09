import { Component, Input, OnInit } from '@angular/core';
import { CategoryDto } from 'src/api';

@Component({
  selector: 'app-category-tree',
  templateUrl: './category-tree.component.html',
  styleUrls: ['./category-tree.component.css']
})
export class CategoryTreeComponent implements OnInit {
  @Input() category: CategoryDto | undefined;

  constructor() { }

  ngOnInit(): void {
  }

}
