import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { NewsService } from "./stock-tracker-api/news.service";
import { HttpClientModule } from "@angular/common/http";

@NgModule({
  providers: [NewsService],
  declarations: [],
  imports: [CommonModule, HttpClientModule],
})
export class InfrastructureModule {}
