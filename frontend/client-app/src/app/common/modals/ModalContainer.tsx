import { observer } from 'mobx-react-lite';
import React from 'react';
import { Modal } from 'semantic-ui-react';
import { useStore } from '../../../stores/store';

export default observer(function ModalContainer() {
    const {modalStore} = useStore();

    return (
        <Modal  style = {{right : '50%', left: '40%', height: 'fit-content', top:'25%'}} open={modalStore.modal.open} onClose={modalStore.closeModal} size='mini'>
            <Modal.Content style = {{right : '30%', left: '30%', height: 'fit-content'}} > 
                {modalStore.modal.body}
            </Modal.Content>
        </Modal>
    )
})