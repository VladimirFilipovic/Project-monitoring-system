import { HeroContainer, HeroBg, VideoBg, HeroContent, HeroH1, HeroP, HeroBtnWrapper, ArrowForward, ArrowRight } from './home-style';
import React, { useState } from 'react'
import { Container } from 'react-dom';
import { NavLink } from 'react-router-dom';
import { Button } from '../../app/Elements/ButtonElement';

export default function Requests() {
    const [hover, setHover] = useState(false)

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
                <HeroBtnWrapper>
                    <Button as={NavLink} to='/requests' onMouseEnter={onHover} onMouseLeave={onHover} >
                        Get started {hover ? <ArrowForward/> : <ArrowRight/>}
                    </Button>
                </HeroBtnWrapper>
            </HeroContent>
        </HeroContainer>
    )
}