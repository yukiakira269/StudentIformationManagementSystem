import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { User } from './user.model';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import firebase from 'firebase/app';
import { AngularFireAuth } from '@angular/fire/auth';
import { AngularFirestore, AngularFirestoreDocument } from '@angular/fire/firestore';

import { Observable, of, throwError } from 'rxjs';
import { catchError, switchMap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  client: HttpClient;
  baseUrl: string;
  user: User;
  user$: Observable<User>;
  constructor(
    private afAuth: AngularFireAuth,
    private afs: AngularFirestore,
    private router: Router,
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.client = http;
    this.baseUrl = baseUrl;
    this.user$ = this.afAuth.authState.pipe(
      switchMap(user => {
        this.user = user;
        // Logged in
        if (user) {
          //Sync with back-end
          localStorage.setItem("USER_MAIL", user.email);
          localStorage.setItem("USER_PHOTO", user.photoURL);
          this.setMail(JSON.stringify(localStorage.getItem("USER_MAIL")))
            .subscribe(mail => { });
          return this.afs.doc<User>(`users/${user.uid}`).valueChanges();
        } else {
          // Logged out
          return of(null);
        }
      })
    )
  }

  async googleSignin() {
    var provider = new firebase.auth.GoogleAuthProvider();
    provider.setCustomParameters({ prompt: 'select_account' });
    const credential = await this.afAuth.signInWithPopup(provider);
    return this.updateUserData(credential.user);
  }

  private async updateUserData(user) {
    // Sets user data to firestore on login
    const userRef: AngularFirestoreDocument<User> = this.afs.doc(`users/${user.uid}`);
    const data = {
      uid: user.uid,
      email: user.email,
      displayName: user.displayName,
      photoURL: user.photoURL
    }

    location.reload();
    userRef.set(data, { merge: true })
  }
  async signOut() {
    localStorage.clear();
    await this.afAuth.signOut();
    location.reload();
  }

  setMail(mail: string): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders(
        { "Content-type": "application/json" }
      )
    };
    return this.client.post(this.baseUrl + "user", mail, httpOptions)
      .pipe(
        catchError((err) => {
          console.error(err);
          return throwError(err.statusText);
        }
        )
      );
  }

}
