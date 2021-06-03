import { observer } from "mobx-react-lite";
import { Redirect, Route, RouteComponentProps, RouteProps } from "react-router-dom";
import { useStore } from "../../stores/store";

interface Props extends RouteProps {
    component: React.ComponentType<RouteComponentProps<any>> | React.ComponentType<any>;
}

export default observer(function PrivateRoute({component: Component, ...rest}: Props) {
    const {userStore: {user}} = useStore();
    return (
        <Route 
            {...rest}
            render={(props) => user ? <Component {...props} /> : <Redirect to='/' />}
        />
    )
})