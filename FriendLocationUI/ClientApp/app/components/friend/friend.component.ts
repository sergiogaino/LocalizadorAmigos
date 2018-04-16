import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'friend',
    templateUrl: './friend.component.html'
})

export class FriendComponent {
    public friends: Friend[];
    public formError: string;  
    public baseUrl: string;

    constructor(private http: Http, @Inject('BASE_URL') url: string) {
        this.baseUrl = url; 
    }

    //Caso queira verificar todos os usuários cadastrados.
    //ngOnInit() {
    //    this.getFriends();
    //}

    getFriends() {
        this.http.get(this.baseUrl + 'api/Friend/ListFriends').subscribe(result => {
            this.friends = result.json() as Friend[];
        }, error => console.error(error));
    }

    getThreFriends(friend: Friend) {
        this.http.post(this.baseUrl + 'api/Friend/ListThreFriends', friend).subscribe(result => {
            this.friends = result.json() as Friend[];
        }, error => console.error(error));
    }

    addFriend(name: string, latitude: number, longitude: number): void {

        this.formError = "";

        if ((name) && (latitude) && (longitude)) {

            var friend = { name: name, latitude: latitude, longitude: longitude } as Friend;

            this.http.post(this.baseUrl + 'api/Friend/Create', friend).subscribe(res => {
                this.getThreFriends(friend);
            }, error => console.error(error));
        }
        else {
            this.formError = "Todos os campos precisam ser preenchidos";
            console.error("Todos os campos precisam ser preenchidos");
        } 
    }

}

interface Friend {
    id: number;
    name: string;
    latitude: number;
    longitude: number;
}
