import { history } from './../index';
import { Login } from './../models/LoginModel';
import { makeAutoObservable, runInAction } from "mobx";
//import { history } from "../..";
import { store } from "./store";
import { User } from '../models/User';
import userservice from '../services/UserService';
import { Register } from '../models/RegisterModel';

export default class UserStore {
    user: User | null = null;
    refreshTokenTimeout: any;

    constructor() {
        makeAutoObservable(this)
    }

    get isLoggedIn() {
        return !!this.user;
    }

    login:any  =  (creds: Login) => {
            let user: User;
            userservice.login(creds).then((res) => {
                user = res.data
                this.user = user;
                if(user.token)
                store.commonStore.setToken(user.token);
                // this.startRefreshTokenTimer(user);
                runInAction(() => this.user = user);
                history.push('/requests');
                store.modalStore.closeModal();
                return user
            }).catch(error => {
                console.log('hey')
                console.log(error)
                throw error
            })
    }


    logout = () => {
        store.commonStore.setToken(null);
        window.localStorage.removeItem('jwt');
        this.user = null;
        history.push('/');
    }

    getUser =  ():any => {
        console.log('get user')
        try {
            userservice.current().then(res => {
                let user:User = res.data
                store.commonStore.setToken(user.token!);
                runInAction(() => this.user = user);
                // this.startRefreshTokenTimer(user);
            });
        } catch (error) {
            console.log(error);
        }
    }

    register = (creds: Register) => {
       return userservice.register(creds).then(res => {
                runInAction(() => this.user = res.data);
                store.commonStore.setToken(res.data.token!);
                store.modalStore.closeModal();
                history.push(`/`);
                console.log(res)
            }).catch(error => {
                console.log(error)
                throw error
            })
           
    }

    // setImage = (image: string) => {
    //     if (this.user) this.user.image = image;
    // } 

    // setDisplayName = (name: string) => {
    //     if (this.user) this.user.displayName = name;
    // }

    // getFacebookLoginStatus = async () => {
    //     window.FB.getLoginStatus(response => {
    //         if (response.status === 'connected') {
    //             this.fbAccessToken = response.authResponse.accessToken;
    //         }
    //     })
    // }

    // facebookLogin = () => {
    //     this.fbLoading = true;
    //     const apiLogin = (accessToken: string) => {
    //         agent.Account.fbLogin(accessToken).then(user => {
    //             store.commonStore.setToken(user.token);
    //             this.startRefreshTokenTimer(user);
    //             runInAction(() => {
    //                 this.user = user;
    //                 this.fbLoading = false;
    //             })
    //             history.push('/activities');
    //         }).catch(error => {
    //             console.log(error);
    //             runInAction(() => this.fbLoading = false);
    //         })
    //     }
    //     if (this.fbAccessToken) {
    //         apiLogin(this.fbAccessToken);
    //     } else {
    //         window.FB.login(response => {
    //             apiLogin(response.authResponse.accessToken);
    //         }, {scope: 'public_profile,email'})
    //     }
    // }

    // refreshToken = async () => {
    //     this.stopRefreshTokenTimer();
    //     try {
    //         const user = await agent.Account.refreshToken();
    //         runInAction(() => this.user = user);
    //         store.commonStore.setToken(user.token);
    //         this.startRefreshTokenTimer(user);
    //     } catch (error) {
    //         console.log(error);
    //     }
    // }

    // private startRefreshTokenTimer(user: User) {
    //     const jwtToken = JSON.parse(atob(user?.token.split('.')[1]));
    //     const expires = new Date(jwtToken.exp * 1000);
    //     const timeout = expires.getTime() - Date.now() - (60 * 1000);
    //     this.refreshTokenTimeout = setTimeout(this.refreshToken, timeout);
    // }

    // private stopRefreshTokenTimer() {
    //     clearTimeout(this.refreshTokenTimeout);
    // }
}