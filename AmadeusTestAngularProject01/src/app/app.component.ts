import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  data: any;
  title = 'Amadeus Test';

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.dataService.getGames().subscribe(response => {
      this.data = response;
      console.log(this.data);
    });

  }
}
