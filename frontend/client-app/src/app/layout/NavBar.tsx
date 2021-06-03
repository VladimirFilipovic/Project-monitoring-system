import { observable } from 'mobx';
import { observer } from 'mobx-react-lite';
import React from 'react';
import { Link, NavLink } from 'react-router-dom';
import { Button, Container, Menu, Image, Dropdown } from 'semantic-ui-react';
import { useStore } from '../../stores/store';

export default observer (function NavBar() {
    const { userStore: { user, logout, getUser} } = useStore();
    const { commonStore: { token} } = useStore();
    

    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item as={NavLink} to='/' exact header>
                    <img src="/assets/logo.png"  alt="logo" style={{marginRight: '10px'}}/>
                    <a href="https://www.freepik.com" title="Freepik"></a>
                    ITSolutions
                </Menu.Item>
               
                {token &&
                <>
                 <Menu.Item as={NavLink} to='/projects' name="Projects"/>
                <Menu.Item>
                    <Button as={NavLink} to='/requests' positive content='Send new request' />
                </Menu.Item>
                <Menu.Item position='right'>
                    <Image src={'/assets/user.png'} avatar spaced='right' />
                    <Dropdown pointing='top left' text={user?.username}>
                        <Dropdown.Menu>
                            <Dropdown.Item onClick={logout} text='Logout' icon='power' />
                        </Dropdown.Menu>
                    </Dropdown>
                </Menu.Item>
                </>}
            </Container>
        </Menu>
    )
})