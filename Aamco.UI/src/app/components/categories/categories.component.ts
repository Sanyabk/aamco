import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  categories: Array<any>;

  constructor() { 
    const subcategories = [
      { name: 'Heading' },
      { name: 'Heading' },
      { name: 'Heading' },
      { name: 'Heading' },
      { name: 'Heading' },
    ];

    this.categories = [
      { id: 1, name: 'Category 1', subcategories: subcategories.slice() },
      { id: 2, name: 'Category 2', subcategories: subcategories.slice() },
      { id: 3, name: 'Category 3', subcategories: subcategories.slice() },
      { id: 4, name: 'Category 4', subcategories: subcategories.slice() },
      { id: 5, name: 'Category 5', subcategories: subcategories.slice() },
    ];
  }

  ngOnInit() {
  }

}
