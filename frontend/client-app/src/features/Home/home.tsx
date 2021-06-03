import { HeroContainer, HeroBg, VideoBg, HeroContent, HeroH1, HeroP, HeroBtnWrapper, ArrowForward, ArrowRight } from './home-style';
import React, { useState } from 'react'
import { Container } from 'react-dom';
import { NavLink } from 'react-router-dom';
import { Button } from '../../app/Elements/ButtonElement';
import { observer } from 'mobx-react-lite';
import { useStore } from '../../stores/store';
import LoginForm from '../users/LoginForm';
import RegisterForm from '../users/RegisterForm';

export default observer (function Requests() {
    const [hover, setHover] = useState(false)
    const {modalStore} = useStore()
    const { userStore: { user, logout, getUser} } = useStore();
    const { commonStore: { token} } = useStore();

    const onHover = () => {
        setHover(!hover)
    }

    return (
        <HeroContainer >
            <HeroBg >
                <VideoBg autoPlay loop muted src="/assets/video.mp4"/>
            </HeroBg>
            <HeroContent >
                <HeroH1> Your projects made easy </HeroH1>
                <HeroP>Send your request and sit back and enjoy</HeroP>
                {!token && <>
                    <HeroBtnWrapper>
                    <Button as={NavLink} to='/' onClick={() => modalStore.openModal(<LoginForm></LoginForm>)} onMouseEnter={onHover} onMouseLeave={onHover} >
                        Login {hover ? <ArrowForward/> : <ArrowRight/>}
                    </Button>
                    <Button as={NavLink} to='/' onClick={() => modalStore.openModal(<RegisterForm></RegisterForm>)} onMouseEnter={onHover} onMouseLeave={onHover} >
                        Register {hover ? <ArrowForward/> : <ArrowRight/>}
                    </Button>
                </HeroBtnWrapper>
                </>
                }
            </HeroContent>
        </HeroContainer>
    )
})