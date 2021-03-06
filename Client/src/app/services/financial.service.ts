import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

@Injectable()
export class FinancialService {

    private serverUrl = 'http://localhost:49822/api';
    private headers = new Headers({'Content-Type': 'application/json'});

    constructor(private http: Http) { }


    getReceivables(): Promise<string[]> {
        const url = this.serverUrl + "/Pendentes/AccountsReceivable";
        return this.http.get(url)
                        .toPromise()
                        .then(response => response.json() as string[])
                        .catch(this.handleError);
    }

    getPayables(): Promise<string[]> {
        const url = this.serverUrl + "/Pendentes/AccountsPayable";
        return this.http.get(url)
                        .toPromise()
                        .then(response => response.json() as string[])
                        .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }

}
