import { createContext, useContext } from "react";
import CommonStore from "./commonStore";
import ModalStore from "./modalStore";
import UserStore from "./userStore";

interface Store {
    userStore: UserStore;
    commonStore: CommonStore
    modalStore: ModalStore;
}

export const store: Store = {
    userStore: new UserStore(),
    modalStore: new ModalStore(),
    commonStore: new CommonStore()

}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}