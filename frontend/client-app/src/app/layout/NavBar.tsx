import React from 'react';
import { NavLink } from 'react-router-dom';
import { Button, Container, Menu } from 'semantic-ui-react';

export default function NavBar() {
    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item as={NavLink} to='/' exact header>
                    <img src="/assets/logo.png"  alt="logo" style={{marginRight: '10px'}}/>
                    <a href="https://www.freepik.com" title="Freepik">_</a>
                    ITSolutions_
                </Menu.Item>
                <Menu.Item as={NavLink} to='/projects' name="Projects"/>
                <Menu.Item>
                    <Button as={NavLink} to='/requests' positive content='Send new request' />
                </Menu.Item>
            </Container>
        </Menu>
    )
}