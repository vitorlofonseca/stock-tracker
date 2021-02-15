import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import * as signalR from "@aspnet/signalr";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class NewsService {
  private newsHubConnection: signalR.HubConnection;

  constructor(private http: HttpClient) {}

  public subscribeToStock() {
    this.newsHubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`https://localhost:5001/initialize-hub/`)
      .build();

    this.newsHubConnection
      .start()
      .then(() => console.log("connection started"))
      .catch(() => console.log("connection failed"));
  }

  public subscribeCompany(stockExchangeCode: string, stockCode: string) {
    this.http
      .get(
        `https://localhost:5001/company/6310f416-139d-4087-8e08-35d8d0ed0719/${stockExchangeCode}/${stockCode}`
      )
      .subscribe((_) => {});

    this.newsHubConnection.on(
      `subscription_${stockExchangeCode}:${stockCode}`,
      (news) => {
        console.log(news);
      }
    );
  }
}
