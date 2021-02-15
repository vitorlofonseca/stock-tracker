import { Component, OnInit } from "@angular/core";
import { NewsService } from "./03-infrastructure/stock-tracker-api/news.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent implements OnInit {
  title = "app";

  constructor(private newsService: NewsService) {}

  ngOnInit() {
    this.newsService.subscribeToStock();
    this.newsService.subscribeCompany("NYSE", "BA");
  }
}
