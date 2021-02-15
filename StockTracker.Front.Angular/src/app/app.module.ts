import { InfrastructureModule } from "./03-infrastructure/infrastructure.module";
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppComponent } from "./app.component";

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, InfrastructureModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
